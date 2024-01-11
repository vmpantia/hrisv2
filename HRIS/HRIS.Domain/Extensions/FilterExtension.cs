using HRIS.Domain.Models.Enums.Filters;
using System.Linq.Expressions;

namespace HRIS.Domain.Extensions
{
    public static class FilterExtension
    {
        public static Expression<Func<TEntity, bool>> GenerateExpressionFilter<TEntity>(string propertyName, object? propertyValue, ConditionFilter condition)
        {
            try
            {
                var (expression, entity) = GetFilterConfiguration<TEntity>(propertyName, propertyValue, condition);
                return Expression.Lambda<Func<TEntity, bool>>(expression, entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in generating expression filter. {ex.Message}");
            }
        }

        private static (Expression, ParameterExpression) GetFilterConfiguration<TEntity>(string propertyName, object? propertyValue, ConditionFilter condition)
        {
            // Get entity and name as data
            var entity = Expression.Parameter(typeof(TEntity), "data");

            // Get property to be use in expression
            var property = Expression.Property(entity, propertyName);

            // Get value to be use in expression
            var value = Expression.Convert(Expression.Constant(propertyValue), property.Type);

            // Get epxression based on the condition value
            Expression expression = condition switch
            {
                ConditionFilter.Equal => GetEqualExpression(property, value),
                ConditionFilter.NotEqual => GetNotEqualExpression(property, value),
                ConditionFilter.Contains => GetContainsMethod(property, value),
                ConditionFilter.NotContains => GetNotContainsMethod(property, value),
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
