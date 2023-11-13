using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Domain.Models.Entities.Versions
{
    public class EmployeeVersion : IEntityVersion
    {
        [Key]
        public DateTime Version { get; set; }
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public CommonStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string? DeletedBy { get; set; }
    }
}
