using HRIS.Domain.Models.Entities;

namespace HRIS.Domain.Extensions
{
    public static class EmployeeExtension
    {
        public static string GetFullName(this Employee employee)
        {
            return $"{employee.LastName.ToTitleCase()}, {employee.FirstName.ToTitleCase()}{(string.IsNullOrEmpty(employee.MiddleName) ? 
                                                                        string.Empty : 
                                                                        ($" {employee.MiddleName.ToTitleCase()[0]}."))}";
        }
    }
}
