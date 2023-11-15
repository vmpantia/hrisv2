using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;

namespace HRIS.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        List<TDto> GetAddresss<TDto>(ISpecification<Address> specification);
        TDto GetAddress<TDto>(ISpecification<Address> specification);
        void CreateAddress(Guid employeeId, SaveAddressDto request, string requestor, bool isAutoSave = false);
        void SyncAddresss(Guid employeeId, List<SaveAddressDto> latestAddresss, string requestor);
        void UpdateAddress(Guid addressId, SaveAddressDto request, string requestor, bool isAutoSave = false);
        void UpdateAddressStatus(Guid addressId, CommonStatus newStatus, string requestor, bool isAutoSave = false);
    }
}