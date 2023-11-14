using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Domain.Models.Entities
{
    public class AddressVersion : IEntityVersion
    {
        [Key]
        public DateTime Version { get; set; }
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string Barangay { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public AddressType Type { get; set; }
        public CommonStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
