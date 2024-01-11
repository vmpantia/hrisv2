using System.ComponentModel;

namespace HRIS.Domain.Models.Enums.Filters
{
    public enum EmployeeFilterPropertyType
    {
        [Description("Number")]
        Id,
        [Description("FirstName")]
        FName,
        [Description("MiddleName")]
        MName,
        [Description("LastName")]
        LName,
        [Description("Gender")]
        Gender
    }
}
