using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Domain.Models.Entities
{
    public class ContactVersion : IEntityVersion
    {
        [Key]
        public DateTime Version { get; set; }
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string Value { get; set; }
        public ContactType Type { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsPersonal { get; set; }
        public CommonStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
