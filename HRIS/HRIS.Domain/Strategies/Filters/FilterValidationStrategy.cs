using HRIS.Domain.Extensions;
using HRIS.Domain.Models.Common.Filters;
using HRIS.Domain.Models.Enums.Filters;

namespace HRIS.Domain.Strategies.Filters
{
    public abstract class FilterValidationStrategy
    {
        public abstract object GetValue<TProperty>(GenericFilterProperty<TProperty> filters) where TProperty : Enum;
    }

    public class EmployeeFilterValidationStrategy : FilterValidationStrategy
    {
        public override object GetValue<TProperty>(GenericFilterProperty<TProperty> filter)
        {
            EmployeeFilterProperty property = filter.Property.GetDescription()
                                                             .GetEnumValue<EmployeeFilterProperty>();
            return (property, filter.Condition) switch
            {
                (_, _) => filter.Value!
            };
        }
    }
}
