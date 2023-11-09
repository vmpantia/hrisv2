using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;
using HRIS.Domain.Specifications;

namespace HRIS.Application.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfwork;
        public EmployeeService(IUnitOfWork unitOfwork) =>
            _unitOfwork = unitOfwork;

        public bool IsEmployeeExist(ISpecification<Employee> specification) =>
            _unitOfwork.Employee.GetByExpression(specification)
                                .Any();

        public List<Employee> GetEmployees(ISpecification<Employee> specification) =>
            _unitOfwork.Employee.GetByExpression(specification)
                                .ToList();

        public Employee GetEmployee(ISpecification<Employee> specification) =>
            _unitOfwork.Employee.GetByExpression(specification)
                                .First();
        
        public void CreateEmployee(SaveEmployeeDto request, string requestor)
        {
            // Map SaveEmployeeDto to Employee
            var employee = _unitOfwork.Mapper.Map<Employee>(request);

            // Set initial data when creating employee
            employee.Id = Guid.NewGuid();
            employee.Number = employee.Id.ToString();
            employee.Status = CommonStatus.Active;
            employee.CreatedAt = DateTime.Now;
            employee.CreatedBy = requestor;

            // Create and Save employee
            _unitOfwork.Employee.Create(employee);
        }

        public void UpdateEmployee(Guid employeeId, SaveEmployeeDto request, string requestor)
        {
            // Prepare employee specification
            var specification = new BaseSpecification<Employee>();
            specification.SetCriteria(data => data.Id == employeeId && data.Status == CommonStatus.Active);

            // Get employee to be update
            var employee = GetEmployee(specification);

            // Map SaveEmployeeDto to Employee
            var updated = _unitOfwork.Mapper.Map(request, employee);

            // Set initial data when updating employee
            updated.UpdatedAt = DateTime.Now;
            updated.UpdatedBy = requestor;

            // Update and Save employee
            _unitOfwork.Employee.Update(updated);
        }

        public void UpdateEmployeeStatus(Guid employeeId, CommonStatus newStatus, string requestor)
        {
            // Prepare employee specification
            var specification = new BaseSpecification<Employee>();
            specification.SetCriteria(data => data.Id == employeeId && data.Status == CommonStatus.Active);

            // Get employee to be update
            var employee = GetEmployee(specification);

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
        }
    }
}
