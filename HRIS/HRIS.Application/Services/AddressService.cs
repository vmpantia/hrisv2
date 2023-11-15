using HRIS.Domain.Exceptions;
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
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfwork;
        public AddressService(IUnitOfWork unitOfwork) =>
            _unitOfwork = unitOfwork;

        public List<TDto> GetAddresss<TDto>(ISpecification<Address> specification) =>
            _unitOfwork.Address.GetByExpression(specification)
                                .Select(data => _unitOfwork.Mapper.Map<TDto>(data))
                                .ToList();

        public TDto GetAddress<TDto>(ISpecification<Address> specification) =>
            _unitOfwork.Address.GetByExpression(specification)
                                .Select(data => _unitOfwork.Mapper.Map<TDto>(data))
                                .First();

        public void CreateAddress(Guid employeeId, SaveAddressDto request, string requestor, bool isAutoSave = false)
        {
            // Map SaveAddressDto to Address
            var address = _unitOfwork.Mapper.Map<Address>(request);

            // Set initial data when creating address
            address.Id = Guid.NewGuid();
            address.EmployeeId = employeeId;
            address.Status = CommonStatus.Active;
            address.CreatedAt = DateUtil.GetCurrentDate();
            address.CreatedBy = requestor;

            _unitOfwork.Address.Create(address);
            _unitOfwork.Address.Version<AddressVersion>(address);

            if (isAutoSave)
                // Save created address if necessary
                _unitOfwork.Save();
        }

        public void UpdateAddress(Guid addressId, SaveAddressDto request, string requestor, bool isAutoSave = false)
        {
            // Prepare address specification
            var specification = new BaseSpecification<Address>();
            specification.SetCriteria(data => data.Id == addressId);

            // Check if the address exist
            if (!_unitOfwork.Address.IsExist(specification))
                throw new NotFoundException("Address not found in the database.");

            // Get address to be update
            var address = _unitOfwork.Address.GetOne(specification);

            // Update address information
            address.Line1 = request.Line1;
            address.Line2 = request.Line2;
            address.Barangay = request.Barangay;
            address.City = request.City;
            address.Province = request.Province;
            address.ZipCode = request.ZipCode;
            address.Country = request.Country;
            address.Type = request.Type;
            address.Status = CommonStatus.Active;
            address.UpdatedAt = DateUtil.GetCurrentDate();
            address.UpdatedBy = requestor;
            address.DeletedAt = null;
            address.DeletedBy = null;

            _unitOfwork.Address.Update(address);
            _unitOfwork.Address.Version<AddressVersion>(address);

            if (isAutoSave)
                // Save updated address if necessary
                _unitOfwork.Save();
        }

        public void UpdateAddressStatus(Guid addressId, CommonStatus newStatus, string requestor, bool isAutoSave = false)
        {
            // Prepare address specification
            var specification = new BaseSpecification<Address>();
            specification.SetCriteria(data => data.Id == addressId);

            // Check if the address exist
            if (!_unitOfwork.Address.IsExist(specification))
                throw new NotFoundException("Address not found in the database.");

            // Get address to be update
            var address = _unitOfwork.Address.GetOne(specification);

            // Update address information
            address.Status = newStatus;
            if (newStatus == CommonStatus.Deleted)
            {
                address.DeletedAt = DateUtil.GetCurrentDate();
                address.DeletedBy = requestor;
            }
            else
            {
                address.UpdatedAt = DateUtil.GetCurrentDate();
                address.UpdatedBy = requestor;
            }

            _unitOfwork.Address.Update(address);
            _unitOfwork.Address.Version<AddressVersion>(address);

            if (isAutoSave)
                // Save updated address if necessary
                _unitOfwork.Save();
        }

        public void SyncAddresss(Guid employeeId, List<SaveAddressDto> latestAddresss, string requestor)
        {
            // Prepare address specification
            var specification = new BaseSpecification<Address>();
            specification.SetCriteria(data => data.EmployeeId == employeeId);

            // Get current addresss from the database
            var currentAddresss = _unitOfwork.Address.GetByExpression(specification);

            // Get currentIds and latestIds from the parameters
            var currentIds = currentAddresss.Select(data => data.Id).Distinct().ToList();
            var latestIds = latestAddresss.Where(data => data.Id != null)
                                          .Select(data => (Guid)data.Id!).Distinct().ToList();

            // Get addresss to be add
            var toBeAdd = latestAddresss.Where(data => data.Id == null).ToList();

            // Get addressIds to be update
            var toBeUpdate = latestIds.Intersect(currentIds);

            // Get addressIds to be delete
            var toBeDelete = currentIds.Except(latestIds);

            // Create employee addresss
            foreach (var address in toBeAdd)
                CreateAddress(employeeId, address, requestor);

            // Update employee addresss
            foreach (var value in toBeUpdate)
            {
                // Get address to request
                var updated = latestAddresss.First(data => data.Id == value);

                UpdateAddress(value, updated, requestor);
            }

            // Delete employee addresss
            foreach (var value in toBeDelete)
                UpdateAddressStatus(value, CommonStatus.Deleted, requestor);
        }
    }
}
