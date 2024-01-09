namespace HRIS.Domain.Models.Common.Filters
{
    public class ResourceFilter<TFilterPropertyType> where TFilterPropertyType : Enum
    {
        public List<CustomFilter<TFilterPropertyType>> Filters { get; set; }
        public Pagination Pagination { get; set; }
    }
}
