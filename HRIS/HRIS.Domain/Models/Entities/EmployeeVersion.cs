using HRIS.Domain.Interfaces.Models;
using System.ComponentModel.DataAnnotations;

namespace HRIS.Domain.Models.Entities
{
    public class EmployeeVersion : Employee, IEntityVersion
    {
        [Key]
        public DateTime Version { get; set; }
    }
}
