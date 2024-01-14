using HRIS.Domain.Models.Enums;

namespace HRIS.Domain.Models.Dtos
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public CommonStatus Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
