using HRIS.Domain.Exceptions;
using HRIS.Domain.Models.Enums.Filters;
using System.Linq.Expressions;

namespace HRIS.Domain.Extensions
{
    public class FilterExtension
    {
        public static Expression<Func<TEntity, bool>> GenerateExpressionFilter<TEntity>(string propertyName, object? propertyValue, ConditionFilterType condition)
        {
            try
            {
                MemberExpression? property = null;

                // Check if the propertyName is null or empty
                if (string.IsNullOrEmpty(propertyName))
                    throw new FilterException("Property Name cannot be NULL or empty when doing filtering.");

                // Get entity and name as data
                var entity = Expression.Parameter(typeof(TEntity), "data");

                // Get property to be use in expression
                foreach (var name in propertyName.Split('.'))
                {
                    if (property == null)
                    {
                        // Main property
                        property = Expression.Property(entity, name);
                        continue;
                    }

                    // Sub property
                    property = Expression.Property(entity, propertyName);
                }

                // Get filter property to be use in expression
                var filterProperty = Expression.Convert(Expression.Constant(propertyValue), property.Type);

                // Get epxression based on the condition value
                Expression expression = condition switch
                {
                    ConditionFilterType.Equals => GetEqualsExpression(property, filterProperty),
                    ConditionFilterType.NotEquals => GetNotEqualsExpression(property, filterProperty),
                    ConditionFilterType.Contains => GetContainsMethod(property, filterProperty),
                    ConditionFilterType.NotContains => GetNotContainsMethod(property, filterProperty),
                    ConditionFilterType.GreaterThan => Expression.GreaterThan(property, filterProperty),
                    ConditionFilterType.GreaterThanOrEqual => Expression.GreaterThanOrEqual(property, filterProperty),
                    ConditionFilterType.LessThan => Expression.LessThan(property, filterProperty),
                    ConditionFilterType.LessThanOrEqual => Expression.LessThanOrEqual(property, filterProperty),
                    _ => throw new NotImplementedException(),
                };

                return Expression.Lambda<Func<TEntity, bool>>(expression, entity);
            }
            catch (Exception ex)
            {
                throw new FilterException($"Error in generating expression filter. {ex.Message}");
            }
        }

        private static Expression GetEqualsExpression(MemberExpression property, UnaryExpression filterProperty)
        {
            if (property.Type != typeof(string))
                return Expression.Equal(property, filterProperty);

            var equalsMethod = typeof(string).GetMethod("Equals", new[] { typeof(string), typeof(StringComparison) });
            return Expression.Call(property, equalsMethod, filterProperty, Expression.Constant(StringComparison.OrdinalIgnoreCase));
        }

        private static Expression GetNotEqualsExpression(MemberExpression property, UnaryExpression filterProperty)
        {
            var equalExpression = GetEqualsExpression(property, filterProperty);
            return Expression.Not(equalExpression);
        }

        private static Expression GetContainsMethod(MemberExpression property, UnaryExpression filterProperty)
        {
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string), typeof(StringComparison) });
            return Expression.Call(property, containsMethod, filterProperty, Expression.Constant(StringComparison.OrdinalIgnoreCase));
        }

        private static Expression GetNotContainsMethod(MemberExpression property, UnaryExpression filterProperty)
        {
            var containsExpression = GetContainsMethod(property, filterProperty);
            return Expression.Not(containsExpression);
        }
    }
}
