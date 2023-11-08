using HRIS.Domain.Interfaces.Models;
using System.Linq.Expressions;

namespace HRIS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression);
        void Create(TEntity entity, bool isAutoSave = false);
        void Update(TEntity entity, bool isAutoSave = false);
        void CreateVersion<TEntityVersion>(TEntity entity, bool isAutoSave = false) where TEntityVersion : class, IEntityVersion;
    }
}