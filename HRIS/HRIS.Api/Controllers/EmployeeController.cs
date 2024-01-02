using HRIS.Domain.Interfaces.Services;
using HRIS.Domain.Models.Common.Filters;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;
using HRIS.Domain.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        public EmployeeController(IEmployeeService employee) =>
            _employee = employee;


        [HttpGet("lite")]
        public IActionResult GetEmployees()
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.AddExpression(data => data.Status == CommonStatus.Active)
                         .AddOrderBy(data => data.CreatedAt);

            // Get employees based on the specification
            var result = _employee.GetEmployees<EmployeeLiteDto>(specification);

            return Ok(result);
        }

        [HttpPost("filter")]
        public IActionResult PostFilterEmployees([FromBody] EmployeeFilter request)
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.AddExpressionFilters(request.Filters)
                         .AddOrderBy(data => data.CreatedAt)
                         .AddInclude(tbl => tbl.Contacts.Where(data => data.Status == CommonStatus.Active))
                         .AddInclude(tbl => tbl.Addresses.Where(data => data.Status == CommonStatus.Active))
                         .SetPagination(request.Pagination);

            // Get employees based on the specification
            var result = _employee.GetEmployees<EmployeeDto>(specification);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.AddExpression(data => data.Id == id)
                         .AddInclude(tbl => tbl.Contacts.Where(data => data.Status == CommonStatus.Active))
                         .AddInclude(tbl => tbl.Addresses.Where(data => data.Status == CommonStatus.Active));

            // Get employee based on the specification
            var result = _employee.GetEmployee<EmployeeDto>(specification);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostEmployee(SaveEmployeeDto request)
        {
            // Create employee
            var result = _employee.CreateEmployee(request, string.Empty);

            return Ok(new { 
                message = "Employee successfully created.", 
                id = result 
            });
        }

        [HttpPut("{id}")]
        public IActionResult PutEmployee(Guid id, SaveEmployeeDto request)
        {
            // Update employee
            _employee.UpdateEmployee(id, request, string.Empty);

            return Ok("Employee successfully updated.");
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEmployeeStatus(Guid id, [FromForm] ChangeCommonStatusDto request)
        {
            // Update employee status
            _employee.UpdateEmployeeStatus(id, request.NewStatus, string.Empty);

            return Ok("Employee successfully updated.");
        }
    }
}