
namespace HRIS.Domain.Models.Common.Filters
{
    public class ResourceFilter<TProperty> where TProperty : Enum
    {
        public List<GenericFilterProperty<TProperty>> Filters { get; set; }
        public Pagination Pagination { get; set; }
    }
}
