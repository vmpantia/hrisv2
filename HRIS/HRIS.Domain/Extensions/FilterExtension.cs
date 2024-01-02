using HRIS.Domain.Models.Enums;
using System.Linq.Expressions;

namespace HRIS.Domain.Extensions
{
    public static class FilterExtension
    {
        public static IEnumerable<TSource> DynamicFilter<TSource>(this IEnumerable<TSource> source, string propertyName, object? propertyValue, ConditionFilterType condition)
        {
            try
            {
                var (expression, entity) = GetFilterConfiguration<TSource>(propertyName, propertyValue, condition);
                var lambda = Expression.Lambda<Func<TSource, bool>>(expression, entity);
                var filteredEntities = source.Where(lambda.Compile());

                return filteredEntities;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in processing dynamic filter. {ex.Message}");
            }
        }

        private static (Expression, ParameterExpression) GetFilterConfiguration<TSource>(string propertyName, object? propertyValue, ConditionFilterType condition)
        {
            // Get entity and name as data
            var entity = Expression.Parameter(typeof(TSource), "data");

            // Get property to be use in expression
            var property = Expression.Property(entity, propertyName);

            // Get value to be use in expression
            var value = Expression.Convert(Expression.Constant(propertyValue), property.Type);

            // Get epxression based on the condition value
            Expression expression = condition switch
            {
                ConditionFilterType.Equal => GetEqualExpression(property, value),
                ConditionFilterType.NotEqual => GetNotEqualExpression(property, value),
                ConditionFilterType.Contains => GetContainsMethod(property, value),
                ConditionFilterType.NotContains => GetNotContainsMethod(property, value),
                _ => throw new NotImplementedException(),
            };

            return (expression, entity);
        }

        private static Expression GetEqualExpression(MemberExpression property, UnaryExpression value)
        {
            if (property.Type != typeof(string))
                return Expression.Equal(property, value);

            var equalsMethod = typeof(string).GetMethod("Equals", new[] { typeof(string), typeof(StringComparison) });
            return Expression.Call(property, equalsMethod, value, Expression.Constant(StringComparison.OrdinalIgnoreCase));
        }

        private static Expression GetNotEqualExpression(MemberExpression property, UnaryExpression value)
        {
            var equalExpression = GetEqualExpression(property, value);
            return Expression.Not(equalExpression);
        }

        private static Expression GetContainsMethod(MemberExpression property, UnaryExpression value)
        {
            var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string), typeof(StringComparison) });
            return Expression.Call(property, containsMethod, value, Expression.Constant(StringComparison.OrdinalIgnoreCase));
        }

        private static Expression GetNotContainsMethod(MemberExpression property, UnaryExpression value)
        {
            var containsExpression = GetContainsMethod(property, value);
            return Expression.Not(containsExpression);
        }
    }
}
