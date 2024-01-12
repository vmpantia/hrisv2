using HRIS.Domain.Exceptions;
using HRIS.Domain.Extensions;
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

namespace HRIS.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly CustomIDHelper _numberHelper;
        private readonly IContactService _contactService;
        private readonly IAddressService _addressService;
        public EmployeeService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
            _numberHelper = new CustomIDHelper(unitOfwork);
            _contactService = new ContactService(unitOfwork);
            _addressService = new AddressService(unitOfwork);
        }

        public List<TDto> GetEmployees<TDto>(ISpecification<Employee> specification) => 
            _unitOfwork.Employee.GetList(specification)
                                .Select(data => _unitOfwork.Mapper.Map<TDto>(data))
                                .ToList();

        public TDto GetEmployee<TDto>(ISpecification<Employee> specification)
        {
            // Check if the employee exist
            if (!_unitOfwork.Employee.IsExist(specification))
                throw new NotFoundException("Employee not found in the database.");

            // Get employee from the database
            var employee = _unitOfwork.Employee.GetOne(specification);

            // Map Employee to EmployeeDto
            return _unitOfwork.Mapper.Map<TDto>(employee);
        }

        public Guid CreateEmployee(SaveEmployeeDto request, string requestor)
        {
            // Map SaveEmployeeDto to Employee
            var employee = _unitOfwork.Mapper.Map<Employee>(request);

            // Set initial data when creating employee
            employee.Id = Guid.NewGuid();
            employee.Number = _numberHelper.GenerateCustomID("ID_NUMBER_EMPLOYEE_PREFIX");
            employee.Status = CommonStatus.Active;
            employee.CreatedAt = DateUtil.GetCurrentDate();
            employee.CreatedBy = requestor;

            // Create employee contacts (corporate email)
            _contactService.CreateCorporateEmail(employee.Id, employee.FirstName, employee.LastName, employee.MiddleName);

            // Create employee contacts
            foreach (var contact in request.Contacts)
                _contactService.CreateContact(employee.Id, contact, requestor);

            // Create employee address
            foreach (var address in request.Addresses)
                _addressService.CreateAddress(employee.Id, address, requestor);

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
            specification.AddExpression(data => data.Id == employeeId);

            // Check if the employee exist
            if (!_unitOfwork.Employee.IsExist(specification))
                throw new NotFoundException("Employee not found in the database.");

            // Get employee to be update
            var employee = _unitOfwork.Employee.GetOne(specification);

            // Check if the employee is active
            if (employee.Status != CommonStatus.Active)
                throw new ValidationException($"Employee cannot be updated since due to status ({employee.Status.GetDescription()}) is not editable.");

            // Update employee information
            employee.FirstName = request.FirstName;
            employee.MiddleName = request.MiddleName;
            employee.LastName = request.LastName;
            employee.Gender = request.Gender;
            employee.BirthDate = request.BirthDate;
            employee.UpdatedAt = DateUtil.GetCurrentDate();
            employee.UpdatedBy = requestor;

            // Sync employee contacts
            _contactService.SyncContacts(employeeId, request.Contacts, requestor);

            // Sync employee address
            _addressService.SyncAddresss(employeeId, request.Addresses, requestor);

            // Update employee
            _unitOfwork.Employee.Update(employee);
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();
        }

        public void UpdateEmployeeStatus(Guid employeeId, CommonStatus newStatus, string requestor)
        {
            // Prepare employee specification
            var specification = new BaseSpecification<Employee>();
            specification.AddExpression(data => data.Id == employeeId && data.Status == CommonStatus.Active);

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
    }
}
