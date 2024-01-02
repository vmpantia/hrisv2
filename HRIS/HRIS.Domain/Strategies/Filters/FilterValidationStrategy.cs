using HRIS.Domain.Extensions;
using HRIS.Domain.Models.Common.Filters;
using HRIS.Domain.Models.Enums.Filters;

namespace HRIS.Domain.Strategies.Filters
{
    public abstract class FilterValidationStrategy
    {
        public abstract object GetValue<TProperty>(CustomFilter<TProperty> filters) where TProperty : Enum;
    }

    public class EmployeeFilterValidationStrategy : FilterValidationStrategy
    {
        public override object GetValue<TProperty>(CustomFilter<TProperty> filter)
        {
            EmployeeFilterPropertyType property = filter.Property.GetDescription().GetEnumValue<EmployeeFilterPropertyType>();
            return (property, filter.Condition) switch
            {
                (_, _) => filter.Value!
            };
        }
    }
}
