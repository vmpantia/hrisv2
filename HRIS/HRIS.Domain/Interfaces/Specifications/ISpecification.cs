using HRIS.Domain.Models.Common;
using System.Linq.Expressions;

namespace HRIS.Domain.Interfaces.Specifications
{
    public interface ISpecification<TEntity>
    {
        List<Expression<Func<TEntity, bool>>> Criteria { get; }
        List<Expression<Func<TEntity, object>>> Includes { get; }
        List<Expression<Func<TEntity, object>>> OrderBy { get; }
        List<Expression<Func<TEntity, object>>> OrderByDescending { get; }
        public int Skip { get; }
        public int Take { get; }
        public bool IsPaginationEnabled { get; }
    }
}
