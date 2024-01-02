using System.Linq.Expressions;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Models.Common;

namespace HRIS.Domain.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public List<Expression<Func<TEntity, bool>>> Criteria { get; private set; } = new List<Expression<Func<TEntity, bool>>>();

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public List<Expression<Func<TEntity, object>>> OrderBy { get; private set; } = new List<Expression<Func<TEntity, object>>>();

        public List<Expression<Func<TEntity, object>>> OrderByDescending { get; private set; } = new List<Expression<Func<TEntity, object>>>();

        public int Skip { get; private set; }
        public int Take { get; private set; }

        public bool IsPaginationEnabled { get; private set; }

        public BaseSpecification<TEntity> AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
            return this;
        }

        public BaseSpecification<TEntity> AddCriteria(Expression<Func<TEntity, bool>> criteriaExpression)
        {
            Criteria.Add(criteriaExpression);
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
            Skip = (pagination.PageNumber - 1) * pagination.PageSize;
            Take = pagination.PageSize;
            IsPaginationEnabled = true;
            return this;
        }
    }
}
