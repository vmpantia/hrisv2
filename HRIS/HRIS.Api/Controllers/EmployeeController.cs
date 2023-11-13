using HRIS.Domain.Interfaces.Services;
using HRIS.Domain.Models.Common;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        public EmployeeController(IEmployeeService employee)
        {
            _employee = employee;
        }

        [HttpPost]
        public IActionResult GetEmployees([FromForm] FilterWithPagination request)
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.SetOrderBy(data => data.CreatedAt)
                         .SetPagination(request);

            // Get employees based on the specification
            var result = _employee.GetEmployees(specification);

            return Ok(result);
        }
    }
}