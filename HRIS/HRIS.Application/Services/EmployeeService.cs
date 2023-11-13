using HRIS.Domain.Exceptions;
using HRIS.Domain.Helpers;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Interfaces.Services;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;
using HRIS.Domain.Specifications;

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

        public List<Employee> GetEmployees(ISpecification<Employee> specification) =>
            _unitOfwork.Employee.GetByExpression(specification)
                                .ToList();

        public Employee GetEmployee(ISpecification<Employee> specification) =>
            _unitOfwork.Employee.GetByExpression(specification)
                                .First();

        public Employee CreateEmployee(SaveEmployeeDto request, string requestor)
        {
            // Map SaveEmployeeDto to Employee
            var employee = _unitOfwork.Mapper.Map<Employee>(request);

            // Set initial data when creating employee
            employee.Id = Guid.NewGuid();
            employee.Number = _numberHelper.GenerateIdNumber("ID_NUMBER_EMPLOYEE_PREFIX");
            employee.Status = CommonStatus.Active;
            employee.CreatedAt = DateTime.Now;
            employee.CreatedBy = requestor;

            // Create and Save employee
            _unitOfwork.Employee.Create(employee);
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();

            return employee;
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
            var employee = GetEmployee(specification);

            // Check if the employee is active
            if (employee.Status != CommonStatus.Active)
                throw new ValidationException($"Employee cannot be updated since due to status ({employee.Status.ToString()}) is not editable.");

            // Map SaveEmployeeDto to Employee
            var updated = _unitOfwork.Mapper.Map(request, employee);

            // Set initial data when updating employee
            updated.UpdatedAt = DateTime.Now;
            updated.UpdatedBy = requestor;

            // Update and Save employee
            _unitOfwork.Employee.Update(updated);
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
            var employee = GetEmployee(specification);

            // Check if the employee current status and new status are same
            if (employee.Status == newStatus)
                throw new ValidationException("Employee current status and new status are the same.");

            // Set initial data when updating employee status
            employee.Status = newStatus;
            if (newStatus == CommonStatus.Deleted)
            {
                employee.DeletedAt = DateTime.Now;
                employee.DeletedBy = requestor;
            }
            else
            {
                employee.UpdatedAt = DateTime.Now;
                employee.UpdatedBy = requestor;
            }

            // Update and Save employee
            _unitOfwork.Employee.Update(employee);
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();
        }
    }
}
