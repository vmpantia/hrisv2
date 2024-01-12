namespace HRIS.Domain.Models.Dtos
{
    public class ContactDto
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsPersonal { get; set; }
        public string Status { get; set; }
    }
}
