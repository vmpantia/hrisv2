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
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }

        public List<ContactDto> Contacts { get; set; }
        public List<AddressDto> Addresses { get; set; }
    }
}
