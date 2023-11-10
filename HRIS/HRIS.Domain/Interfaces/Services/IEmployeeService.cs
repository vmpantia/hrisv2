using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;

namespace HRIS.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        void CreateEmployee(SaveEmployeeDto request, string requestor);
        Employee GetEmployee(ISpecification<Employee> specification);
        List<Employee> GetEmployees(ISpecification<Employee> specification);
        bool IsEmployeeExist(ISpecification<Employee> specification);
        void UpdateEmployee(Guid employeeId, SaveEmployeeDto request, string requestor);
        void UpdateEmployeeStatus(Guid employeeId, CommonStatus newStatus, string requestor);
    }
}