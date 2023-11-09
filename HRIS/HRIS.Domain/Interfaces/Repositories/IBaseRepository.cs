using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Specifications;
using System.Linq.Expressions;

namespace HRIS.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(ISpecification<TEntity> specification = null);
        IEnumerable<TEntity> GetByExpression(ISpecification<TEntity> specification);
        void Create(TEntity entity, bool isAutoSave = false);
        void Update(TEntity entity, bool isAutoSave = false);
        void CreateVersion<TEntityVersion>(TEntity entity, bool isAutoSave = false) where TEntityVersion : class, IEntityVersion;
    }
}