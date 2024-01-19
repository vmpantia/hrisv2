using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Interfaces.Specifications;

namespace HRIS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        bool IsExist(ISpecification<TEntity> specification);
        int Count(ISpecification<TEntity> specification);
        IEnumerable<TEntity> GetList(ISpecification<TEntity> specification);
        TEntity GetOne(ISpecification<TEntity> specification);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Version<TEntityVersion>(TEntity entity) where TEntityVersion : class, IEntityVersion;
    }
}