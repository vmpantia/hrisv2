using HRIS.Domain.Helpers;
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
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfwork;
        private readonly IDNumberHelper _numberHelper;
        public EmployeeService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
            _numberHelper = new IDNumberHelper(unitOfwork);
        }

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
            employee.Number = _numberHelper.GenerateIdNumber("ID_NUMBER_EMPLOYEE_PREFIX");
            employee.Status = CommonStatus.Active;
            employee.CreatedAt = DateTime.Now;
            employee.CreatedBy = requestor;

            // Create and Save employee
            _unitOfwork.Employee.Create(employee);
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();
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
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();
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
            _unitOfwork.Employee.Version<EmployeeVersion>(employee);
            _unitOfwork.Save();
        }
    }
}
