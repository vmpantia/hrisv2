using HRIS.Domain.Models.Enums.Filters;

namespace HRIS.Domain.Models.Common.Filters
{
    public class EmployeeFilter
    {
        public List<CustomFilter<EmployeeFilterPropertyType>> Filters { get; set; }
        public Pagination Pagination { get; set; }
    }
}
