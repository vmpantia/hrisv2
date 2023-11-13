using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Interfaces.Specifications;

namespace HRIS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool IsExist(ISpecification<TEntity> specification);
        IEnumerable<TEntity> GetByExpression(ISpecification<TEntity> specification);
        TEntity GetOne(ISpecification<TEntity> specification);
        void Create(TEntity entity, bool isAutoSave = false);
        void Update(TEntity entity, bool isAutoSave = false);
        void Version<TEntityVersion>(TEntity entity, bool isAutoSave = false) where TEntityVersion : class, IEntityVersion;
    }
}