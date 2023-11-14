using HRIS.Domain.Exceptions;
using HRIS.Domain.Helpers;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Interfaces.Services;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Entities.Versions;
using HRIS.Domain.Models.Enums;
using HRIS.Domain.Specifications;
using HRIS.Domain.Utils;
using System.Net;

namespace HRIS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IDNumberHelper _numberHelper;
        public EmployeeService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
            _numberHelper = new IDNumberHelper(unitOfwork);
        }

        public List<TDto> GetEmployees<TDto>(ISpecification<Employee> specification) => 
            _unitOfwork.Employee.GetByExpression(specification)
                                .Select(data => _unitOfwork.Mapper.Map<TDto>(data))
                                .ToList();

        public TDto GetEmployee<TDto>(ISpecification<Employee> specification) =>
            _unitOfwork.Employee.GetByExpression(specification)
                                .Select(data => _unitOfwork.Mapper.Map<TDto>(data))
                                .First();

        public Guid CreateEmployee(SaveEmployeeDto request, string requestor)
        {
            // Map SaveEmployeeDto to Employee
            var employee = _unitOfwork.Mapper.Map<Employee>(request);

            // Set initial data when creating employee
            employee.Id = Guid.NewGuid();
            employee.Number = _numberHelper.GenerateIdNumber("ID_NUMBER_EMPLOYEE_PREFIX");
            employee.Status = CommonStatus.Active;
            employee.CreatedAt = DateUtil.GetCurrentDate();
            employee.CreatedBy = requestor;

            #region Create employee contacts
            // Create employee contacts
            foreach (var contact in employee.Contacts)
            {
                contact.Id = Guid.NewGuid();
                contact.EmployeeId = employee.Id;
                contact.Status = CommonStatus.Active;
                contact.CreatedAt = DateUtil.GetCurrentDate();
                contact.CreatedBy = requestor;

                _unitOfwork.Contact.Create(contact);
                _unitOfwork.Contact.Version<ContactVersion>(contact);
            }
            #endregion

            #region Create employee address
            // Create employee address
            foreach (var address in employee.Addresses)
            {
                address.Id = Guid.NewGuid();
                address.EmployeeId = employee.Id;
                address.Status = CommonStatus.Active;
                address.CreatedAt = DateUtil.GetCurrentDate();
                address.CreatedBy = requestor;

                _unitOfwork.Address.Create(address);
                _unitOfwork.Address.Version<AddressVersion>(address);
            }
            #endregion

            // Create employee information
            _unitOfwork.Employee.Create(employee);
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);

            // Save all information of new employee
            _unitOfwork.Save();

            return employee.Id;
        }

        public void UpdateEmployee(Guid employeeId, SaveEmployeeDto request, string requestor)
        {
            // Prepare employee specification
            var specification = new BaseSpecification<Employee>();
            specification.SetCriteria(data => data.Id == employeeId);

            // Check if the employee exist
            if (!_unitOfwork.Employee.IsExist(specification))
                throw new NotFoundException("Employee not found in the database.");

            // Get employee to be update
            var employee = _unitOfwork.Employee.GetOne(specification);

            // Check if the employee is active
            if (employee.Status != CommonStatus.Active)
                throw new ValidationException($"Employee cannot be updated since due to status ({employee.Status.ToString()}) is not editable.");

            // Update employee information
            employee.FirstName = request.FirstName;
            employee.MiddleName = request.MiddleName;
            employee.LastName = request.LastName;
            employee.Gender = request.Gender;
            employee.BirthDate = request.BirthDate;
            employee.UpdatedAt = DateUtil.GetCurrentDate();
            employee.UpdatedBy = requestor;

            // Sync employee contacts
            SyncEmployeeContacts(employeeId, request.Contacts, requestor);

            // Update employee
            _unitOfwork.Employee.Update(employee);
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();
        }

        public void UpdateEmployeeStatus(Guid employeeId, CommonStatus newStatus, string requestor)
        {
            // Prepare employee specification
            var specification = new BaseSpecification<Employee>();
            specification.SetCriteria(data => data.Id == employeeId && data.Status == CommonStatus.Active);

            // Check if the employee exist
            if (!_unitOfwork.Employee.IsExist(specification))
                throw new NotFoundException("Employee not found in the database.");

            // Get employee to be update
            var employee = _unitOfwork.Employee.GetOne(specification);

            // Check if the employee current status and new status are same
            if (employee.Status == newStatus)
                throw new ValidationException("Employee current status and new status are the same.");

            // Update employee information
            employee.Status = newStatus;
            if (newStatus == CommonStatus.Deleted)
            {
                employee.DeletedAt = DateUtil.GetCurrentDate();
                employee.DeletedBy = requestor;
            }
            else
            {
                employee.UpdatedAt = DateUtil.GetCurrentDate();
                employee.UpdatedBy = requestor;
            }

            // Update and Save employee
            _unitOfwork.Employee.Update(employee);
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();
        }

        public void SyncEmployeeContacts(Guid employeeId, List<SaveContactDto> latestContacts, string requestor)
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

            #region Create employee contacts
            // Create employee contacts
            foreach (var contact in toBeAdd)
            {
                // Map SaveContactDto to Contact
                var newContact = _unitOfwork.Mapper.Map<Contact>(contact);
                newContact.Id = Guid.NewGuid();
                newContact.EmployeeId = employeeId;
                newContact.Status = CommonStatus.Active;
                newContact.CreatedAt = DateUtil.GetCurrentDate();
                newContact.CreatedBy = requestor;

                _unitOfwork.Contact.Create(newContact);
                _unitOfwork.Contact.Version<ContactVersion>(newContact);
            }
            #endregion

            #region Update employee contacts
            // Update employee contacts
            foreach (var value in toBeUpdate)
            {
                // Get contact to be update
                var contact = currentContacts.FirstOrDefault(data => data.Id == value);

                // Check if the contact to be update is exist
                if (contact == null)
                    throw new NotFoundException("Contact to update not found in the employee contacts.");

                // Get updated contact information from request
                var updated = latestContacts.First(data => data.Id == value);

                // Update contact information
                contact.Value = updated.Value;
                contact.Type = updated.Type;
                contact.IsPrimary = updated.IsPrimary;
                contact.Status = CommonStatus.Active;
                contact.UpdatedAt = DateUtil.GetCurrentDate();
                contact.UpdatedBy = requestor;
                contact.DeletedAt = null;
                contact.DeletedBy = null;

                _unitOfwork.Contact.Update(contact);
                _unitOfwork.Contact.Version<ContactVersion>(contact);
            }
            #endregion

            #region Delete employee contacts
            // Delete employee contacts
            foreach (var value in toBeDelete)
            {
                // Get contact to be delete
                var contact = currentContacts.FirstOrDefault(data => data.Id == value);

                // Check if the contact to be delete is exist
                if (contact == null)
                    throw new NotFoundException("Contact to delete not found in the employee contacts.");

                // Delete contact information
                contact.Status = CommonStatus.Deleted;
                contact.DeletedAt = DateUtil.GetCurrentDate();
                contact.DeletedBy = requestor;

                _unitOfwork.Contact.Update(contact);
                _unitOfwork.Contact.Version<ContactVersion>(contact);
            }
            #endregion
        }
    }
}
