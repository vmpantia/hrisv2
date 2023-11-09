using System.Linq.Expressions;

namespace HRIS.Domain.Specifications
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity>
    {
        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<TEntity, bool>> Criteria) =>
            this.Criteria = Criteria;

        public Expression<Func<TEntity, bool>> Criteria { get; private set; }

        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }

        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool isPagingEnabled { get; private set; }

        public void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
            Includes.Add(includeExpression);

        public void SetCriteria(Expression<Func<TEntity, bool>> criteriaExpression) =>
            Criteria = criteriaExpression;

        public void SetOrderBy(Expression<Func<TEntity, object>> OrderByexpression) =>
            OrderBy = OrderByexpression;

        public void SetOrderByDecending(Expression<Func<TEntity, object>> OrderByDecending) =>
            OrderByDescending = OrderByDecending;

        public void ApplyPagging(int take, int skip)
        {
            Take = take;
            Skip = skip;
            isPagingEnabled = true;
        }
    }
}
