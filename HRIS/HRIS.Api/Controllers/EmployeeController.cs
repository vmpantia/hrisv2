using HRIS.Domain.Interfaces.Services;
using HRIS.Domain.Models.Common.Filters;
using HRIS.Domain.Models.Dtos;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;
using HRIS.Domain.Models.Enums.Filters;
using HRIS.Domain.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace HRIS.Api.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employee;
        private readonly IContactService _contact;
        private readonly IAddressService _address;
        public EmployeeController(IEmployeeService employee, IContactService contact, IAddressService address)
        {
            _employee = employee;
            _contact = contact;
            _address = address;
        }

        #region Employee
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
        public IActionResult PostFilterEmployees(ResourceFilter<EmployeeFilterPropertyType> request)
        {
            // Set specification for getting employees
            var specification = new BaseSpecification<Employee>();
            specification.AddExpression(data => data.Status != CommonStatus.Deleted)
                         .AddExpressionFilters(request.Filters)
                         .AddInclude(tbl => tbl.Contacts.Where(data => data.IsPrimary && data.Status == CommonStatus.Active))
                         .AddInclude(tbl => tbl.Addresses.Where(data => data.Type == AddressType.Primary && data.Status == CommonStatus.Active))
                         .AddOrderBy(data => data.CreatedAt)
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
            specification.AddExpression(data => data.Id == id &&
                                                data.Status == CommonStatus.Active);

            // Get employee based on the specification
            var result = _employee.GetEmployee<EmployeeDto>(specification);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult PostEmployee(SaveEmployeeDto request)
        {
            // Create employee
            var result = _employee.CreateEmployee(request, string.Empty);

            return Ok(new
            {
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
        public IActionResult PatchEmployeeStatus(Guid id, UpdateCommonStatusDto request)
        {
            // Update employee status
            _employee.UpdateEmployeeStatus(id, request.NewStatus, string.Empty);

            return Ok("Employee successfully updated.");
        }
        #endregion

        #region Employee Contact
        [HttpGet("{employeeId}/contacts")]
        public IActionResult GetEmployeeContacts(Guid employeeId)
        {
            // Set specification for getting contacts
            var specification = new BaseSpecification<Contact>();
            specification.AddExpression(data => data.EmployeeId == employeeId &&
                                                data.Status == CommonStatus.Active);

            // Get contacts based on the specification
            var result = _contact.GetContacts<ContactDto>(specification);

            return Ok(result);
        }

        [HttpGet("{employeeId}/contact/primary")]
        public IActionResult GetEmployeePrimaryContact(Guid employeeId)
        {
            // Set specification for getting contacts
            var specification = new BaseSpecification<Contact>();
            specification.AddExpression(data => data.EmployeeId == employeeId &&
                                                data.IsPrimary == true &&
                                                data.Status == CommonStatus.Active);

            // Get contacts based on the specification
            var result = _contact.GetContact<ContactDto>(specification);

            return Ok(result);
        }
        #endregion

        #region Employee Address
        [HttpGet("{employeeId}/addresses")]
        public IActionResult GetEmployeeAddresses(Guid employeeId)
        {
            // Set specification for getting addresses
            var specification = new BaseSpecification<Address>();
            specification.AddExpression(data => data.EmployeeId == employeeId &&
                                                data.Status == CommonStatus.Active);

            // Get addresses based on the specification
            var result = _address.GetAddresses<AddressDto>(specification);

            return Ok(result);
        }

        [HttpGet("{employeeId}/address/primary")]
        public IActionResult GetEmployeePrimaryAddress(Guid employeeId)
        {
            // Set specification for getting addresses
            var specification = new BaseSpecification<Address>();
            specification.AddExpression(data => data.EmployeeId == employeeId &&
                                                data.Type == AddressType.Primary &&
                                                data.Status == CommonStatus.Active);

            // Get addresses based on the specification
            var result = _address.GetAddress<AddressDto>(specification);

            return Ok(result);
        }
        #endregion
    }
}