﻿using System.Linq.Expressions;

namespace HRIS.Domain.Specifications
{
    public interface ISpecification<TEntity>
    {
        Expression<Func<TEntity, bool>> Criteria  { get; }
        List<Expression<Func<TEntity, object>>> Includes  { get; }
        Expression<Func<TEntity, object>> OrderBy { get; }
        Expression<Func<TEntity, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        bool isPagingEnabled {  get; }
    }
}
