using HRIS.Domain.Interfaces.Services;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Common;
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

        [HttpGet]
        public IActionResult GetEmployees([FromQuery] FilterWithPagination request)
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.SetOrderBy(data => data.CreatedAt)
                         .SetPagination(request)
                         .AddInclude(tbl => tbl.Contacts.Where(data => data.Status == CommonStatus.Active))
                         .AddInclude(tbl => tbl.Addresses.Where(data => data.Status == CommonStatus.Active));

            // Get employees based on the specification
            var result = _employee.GetEmployees<EmployeeDto>(specification);

            return Ok(result);
        }

        [HttpGet("lite")]
        public IActionResult GetEmployees()
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.SetCriteria(data => data.Status == CommonStatus.Active)
                         .SetOrderBy(data => data.CreatedAt);

            // Get employees based on the specification
            var result = _employee.GetEmployees<EmployeeLiteDto>(specification);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.SetCriteria(data => data.Id == id)
                         .AddInclude(tbl => tbl.Contacts.Where(data => data.Status == CommonStatus.Active))
                         .AddInclude(tbl => tbl.Addresses.Where(data => data.Status == CommonStatus.Active));

            // Get employee based on the specification
            var result = _employee.GetEmployee<EmployeeDto>(specification);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostEmployee([FromForm] SaveEmployeeDto request)
        {
            // Create employee
            var result = _employee.CreateEmployee(request, string.Empty);

            return Ok(new { 
                message = "Employee successfully created.", 
                id = result 
            });
        }

        [HttpPut("{id}")]
        public IActionResult PutEmployee(Guid id, [FromForm] SaveEmployeeDto request)
        {
            // Update employee
            _employee.UpdateEmployee(id, request, string.Empty);

            return Ok("Employee successfully updated");
        }

        [HttpPatch("{id}")]
        public IActionResult PatchEmployeeStatus(Guid id, [FromForm] ChangeCommonStatusDto request)
        {
            // Update employee status
            _employee.UpdateEmployeeStatus(id, request.NewStatus, string.Empty);

            return Ok("Employee successfully updated");
        }
    }
}