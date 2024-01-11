using HRIS.Domain.Models.Enums.Filters;

namespace HRIS.Domain.Models.Common.Filters
{
    public class CustomFilter<TProperty> where TProperty : Enum
    {
        public TProperty Property { get; set; }
        public string? Value { get; set; }
        public ConditionFilterType Condition { get; set; }
    }
}
