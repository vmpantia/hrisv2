namespace HRIS.Domain.Models.Dtos
{
    public class AddressDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Address { get; set; }
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Type { get; set; }
        public bool IsPrimary { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
    }
}
