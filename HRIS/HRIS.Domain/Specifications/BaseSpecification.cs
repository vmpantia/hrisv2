using System.Collections.Immutable;
using System.Linq.Expressions;
using HRIS.Domain.Extensions;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Common;
using HRIS.Domain.Models.Common.Filters;
using HRIS.Domain.Models.Enums.Filters;
using HRIS.Domain.Strategies.Filters;

namespace HRIS.Domain.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        private readonly Dictionary<Type, FilterValidationStrategy> _filterValidationStrategies;
        public BaseSpecification()
        {
            _filterValidationStrategies = new Dictionary<Type, FilterValidationStrategy>
            {
                { typeof(EmployeeFilterPropertyType), new EmployeeFilterValidationStrategy() },
            };
        }

        public List<Expression<Func<TEntity, bool>>> Expressions { get; private set; } = new List<Expression<Func<TEntity, bool>>>();
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
        public List<Expression<Func<TEntity, object>>> OrderBy { get; private set; } = new List<Expression<Func<TEntity, object>>>();
        public List<Expression<Func<TEntity, object>>> OrderByDescending { get; private set; } = new List<Expression<Func<TEntity, object>>>();
        public int Skip { get; private set; }
        public int Take { get; private set; }
        public bool IsPaginationEnabled { get; private set; }
        public bool IsSplitQuery { get; private set; } = false;
        public int CountFilteredData { get; set; }

        public BaseSpecification<TEntity> AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
            return this;
        }

        public BaseSpecification<TEntity> AddExpression(Expression<Func<TEntity, bool>> expression)
        {
            Expressions.Add(expression);
            return this;
        }

        public BaseSpecification<TEntity> AddExpressionFilters<TProperty>(List<CustomFilter<TProperty>> filters) where TProperty : Enum 
        {
            foreach(var filter in filters)
            {
                // Get strategy
                var strategy = _filterValidationStrategies.GetValueOrDefault(typeof(TProperty));
                if (strategy == null)
                    throw new NotImplementedException("Filter validation strategy not found.");

                // Get expression by strategy
                var expression = FilterExtension.GenerateExpressionFilter<TEntity>(filter.Property.GetDescription(), 
                                                                                   strategy.GetValue(filter), 
                                                                                   filter.Condition);
                Expressions.Add(expression);
            }
            return this;
        }

        public BaseSpecification<TEntity> AddOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy.Add(orderByExpression);
            return this;
        }

        public BaseSpecification<TEntity> AddOrderByDecending(Expression<Func<TEntity, object>> orderByDescending)
        {
            OrderByDescending.Add(orderByDescending);
            return this;
        }

        public BaseSpecification<TEntity> SetPagination(Pagination pagination)
        {
            Skip = (pagination.PageIndex) * pagination.PageSize;
            Take = pagination.PageSize;
            IsPaginationEnabled = true;
            return this;
        }

        public BaseSpecification<TEntity> SetSplitQuery(bool isSplitQuery)
        {
            IsSplitQuery = isSplitQuery;
            return this;
        }
    }
}
