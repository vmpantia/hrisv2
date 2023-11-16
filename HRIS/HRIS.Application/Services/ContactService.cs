using HRIS.Domain.Exceptions;
using HRIS.Domain.Extensions;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Interfaces.Services;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;
using HRIS.Domain.Specifications;
using HRIS.Domain.Utils;

namespace HRIS.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfwork;
        public ContactService(IUnitOfWork unitOfwork) =>
            _unitOfwork = unitOfwork;

        public List<TDto> GetContacts<TDto>(ISpecification<Contact> specification) =>
            _unitOfwork.Contact.GetByExpression(specification)
                                .Select(data => _unitOfwork.Mapper.Map<TDto>(data))
                                .ToList();

        public TDto GetContact<TDto>(ISpecification<Contact> specification) =>
            _unitOfwork.Contact.GetByExpression(specification)
                                .Select(data => _unitOfwork.Mapper.Map<TDto>(data))
                                .First();

        public void CreateCorporateEmail(Guid employeeId, string firstName, string lastName, string? middleName)
        {
            // Get company domain
            var domain = _unitOfwork.Config.GetValue<string>("SYSTEM", "COMPANY_DOMAIN");

            // Remove special characters
            var modifiedFName = firstName.RemoveSpecialCharacters();
            var modifiedLName = lastName.RemoveSpecialCharacters();
            var modifiedMName = middleName.RemoveSpecialCharacters();

            // Get middle initial
            var middleInitial = string.IsNullOrEmpty(modifiedMName) ? string.Empty : modifiedMName[0].ToString();

            // Get unique id from employee id
            var uniqueId = employeeId.ToString().Substring(0, 8);

            // Generate corporate email for employee
            var email = $"{modifiedFName}.{middleInitial}.{modifiedLName}.{uniqueId}@{domain}";

            // Prepare contact to be create
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                EmployeeId = employeeId,
                Value = email,
                Type = ContactType.Email,
                IsPrimary = true,
                IsPersonal = false,
                Status = CommonStatus.Active,
                CreatedAt = DateUtil.GetCurrentDate(),
                CreatedBy = "System"
            };

            _unitOfwork.Contact.Create(contact);
            _unitOfwork.Contact.Version<ContactVersion>(contact);
        }

        public void CreateContact(Guid employeeId, SaveContactDto request, string requestor, bool isAutoSave = false)
        {
            // Map SaveContactDto to Contact
            var contact = _unitOfwork.Mapper.Map<Contact>(request);

            // Set initial data when creating contact
            contact.Id = Guid.NewGuid();
            contact.EmployeeId = employeeId;
            contact.Status = CommonStatus.Active;
            contact.CreatedAt = DateUtil.GetCurrentDate();
            contact.CreatedBy = requestor;

            _unitOfwork.Contact.Create(contact);
            _unitOfwork.Contact.Version<ContactVersion>(contact);

            if (isAutoSave)
                // Save created contact if necessary
                _unitOfwork.Save();
        }

        public void UpdateContact(Guid contactId, SaveContactDto request, string requestor, bool isAutoSave = false)
        {
            // Prepare contact specification
            var specification = new BaseSpecification<Contact>();
            specification.SetCriteria(data => data.Id == contactId);

            // Check if the contact exist
            if (!_unitOfwork.Contact.IsExist(specification))
                throw new NotFoundException("Contact not found in the database.");

            // Get contact to be update
            var contact = _unitOfwork.Contact.GetOne(specification);

            // Update contact information
            contact.Value = request.Value;
            contact.Type = request.Type;
            contact.IsPrimary = request.IsPrimary;
            contact.Status = CommonStatus.Active;
            contact.UpdatedAt = DateUtil.GetCurrentDate();
            contact.UpdatedBy = requestor;
            contact.DeletedAt = null;
            contact.DeletedBy = null;

            _unitOfwork.Contact.Update(contact);
            _unitOfwork.Contact.Version<ContactVersion>(contact);

            if (isAutoSave)
                // Save updated contact if necessary
                _unitOfwork.Save();
        }

        public void UpdateContactStatus(Guid contactId, CommonStatus newStatus, string requestor, bool isAutoSave = false)
        {
            // Prepare contact specification
            var specification = new BaseSpecification<Contact>();
            specification.SetCriteria(data => data.Id == contactId);

            // Check if the contact exist
            if (!_unitOfwork.Contact.IsExist(specification))
                throw new NotFoundException("Contact not found in the database.");

            // Get contact to be update
            var contact = _unitOfwork.Contact.GetOne(specification);

            // Update contact information
            contact.Status = newStatus;
            if (newStatus == CommonStatus.Deleted)
            {
                contact.DeletedAt = DateUtil.GetCurrentDate();
                contact.DeletedBy = requestor;
            }
            else
            {
                contact.UpdatedAt = DateUtil.GetCurrentDate();
                contact.UpdatedBy = requestor;
            }

            _unitOfwork.Contact.Update(contact);
            _unitOfwork.Contact.Version<ContactVersion>(contact);

            if (isAutoSave)
                // Save updated contact if necessary
                _unitOfwork.Save();
        }

        public void SyncContacts(Guid employeeId, List<SaveContactDto> latestContacts, string requestor)
        {
            // Prepare contact specification
            var specification = new BaseSpecification<Contact>();
            specification.SetCriteria(data => data.EmployeeId == employeeId);

            // Get current contacts from the database
            var currentContacts = _unitOfwork.Contact.GetByExpression(specification);

            // Get currentIds and latestIds from the parameters
            var currentIds = currentContacts.Select(data => data.Id).Distinct().ToList();
            var latestIds = latestContacts.Where(data => data.Id != null)
                                          .Select(data => (Guid)data.Id!).Distinct().ToList();

            // Get contacts to be add
            var toBeAdd = latestContacts.Where(data => data.Id == null).ToList();

            // Get contactIds to be update
            var toBeUpdate = latestIds.Intersect(currentIds);

            // Get contactIds to be delete
            var toBeDelete = currentIds.Except(latestIds);

            // Create employee contacts
            foreach (var contact in toBeAdd)
                CreateContact(employeeId, contact, requestor);

            // Update employee contacts
            foreach (var value in toBeUpdate)
            {
                // Get contact to request
                var updated = latestContacts.First(data => data.Id == value);

                UpdateContact(value, updated, requestor);
            }

            // Delete employee contacts
            foreach (var value in toBeDelete)
                UpdateContactStatus(value, CommonStatus.Deleted, requestor);
        }
    }
}
