using System.Linq.Expressions;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Common;

namespace HRIS.Domain.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public int Skip { get; private set; }
        public int Take { get; private set; }

        public bool IsPaginationEnabled { get; private set; }

        public BaseSpecification<TEntity> AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
            return this;
        }

        public BaseSpecification<TEntity> SetCriteria(Expression<Func<TEntity, bool>> criteriaExpression)
        {
            Criteria = criteriaExpression;
            return this;
        }

        public BaseSpecification<TEntity> SetOrderBy(Expression<Func<TEntity, object>> OrderByexpression)
        {
            OrderBy = OrderByexpression;
            return this;
        }

        public BaseSpecification<TEntity> SetOrderByDecending(Expression<Func<TEntity, object>> OrderByDecending)
        {
            OrderByDescending = OrderByDecending;
            return this;
        }

        public BaseSpecification<TEntity> SetPagination(Pagination pagination)
        {
            Skip = (pagination.PageNumber - 1) * pagination.PageSize;
            Take = pagination.PageSize;
            IsPaginationEnabled = true;
            return this;
        }
    }
}
