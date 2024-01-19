using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;

namespace HRIS.Domain.Interfaces.Services
{
    public interface IEmployeeService
    {
        int Count(ISpecification<Employee> specification);
        List<TDto> GetEmployees<TDto>(ISpecification<Employee> specification);
        TDto GetEmployee<TDto>(ISpecification<Employee> specification);
        Guid CreateEmployee(SaveEmployeeDto request, string requestor);
        void UpdateEmployee(Guid employeeId, SaveEmployeeDto request, string requestor);
        void UpdateEmployeeStatus(Guid employeeId, CommonStatus newStatus, string requestor);
    }
}