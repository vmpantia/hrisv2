using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;

namespace HRIS.Domain.Interfaces.Services
{
    public interface IContactService
    {
        List<TDto> GetContacts<TDto>(ISpecification<Contact> specification);
        TDto GetContact<TDto>(ISpecification<Contact> specification);
        void CreateContact(Guid employeeId, SaveContactDto request, string requestor, bool isAutoSave = false);
        void SyncContacts(Guid employeeId, List<SaveContactDto> latestContacts, string requestor);
        void UpdateContact(Guid contactId, SaveContactDto request, string requestor, bool isAutoSave = false);
        void UpdateContactStatus(Guid contactId, CommonStatus newStatus, string requestor, bool isAutoSave = false);
    }
}