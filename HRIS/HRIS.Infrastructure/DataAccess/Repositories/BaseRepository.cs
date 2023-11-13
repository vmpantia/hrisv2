using AutoMapper;
using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Interfaces.Specifications;
using HRIS.Domain.Utils;
using HRIS.Infrastructure.DataAccess.Database;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly HRISDbContext _context;
        protected readonly IMapper _mapper;
        protected readonly DbSet<TEntity> _table;
        public BaseRepository(HRISDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _table = context.Set<TEntity>();
        }

        public bool IsExist(ISpecification<TEntity> specification)
        {
            if (specification.Criteria == null)
                throw new Exception("Specification criteria cannot be NULL when checking if the data exist.");

            return _table.Any(specification.Criteria);
        }

        public IEnumerable<TEntity> GetByExpression(ISpecification<TEntity> specification)
        {
            var result = _table.AsNoTracking();

            if (specification.Criteria != null)
                result = _table.Where(specification.Criteria);

            if (specification.IsPaginationEnabled)
                result = result.Take(specification.Take).Skip(specification.Skip);

            if (specification.OrderBy != null)
                result = result.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending != null)
                result = result.OrderByDescending(specification.OrderByDescending);

            return specification.Includes.Aggregate(result, (current, include) => current.Include(include));
        }

        public TEntity GetOne(ISpecification<TEntity> specification)
        {
            if (specification.Criteria == null)
                throw new Exception("Specification criteria cannot be NULL when getting one record.");

            return _table.First(specification.Criteria);
        }

        public void Create(TEntity entity, bool isAutoSave = false)
        {
            _table.Add(entity);

            if (isAutoSave)
                _context.SaveChanges();
        }

        public void Update(TEntity entity, bool isAutoSave = false)
        {
            _table.Update(entity);

            if (isAutoSave)
                _context.SaveChanges();
        }

        public void Version<TEntityVersion>(TEntity entity, bool isAutoSave = false) where TEntityVersion : class, IEntityVersion
        {
            var latestVersion = _mapper.Map<TEntityVersion>(entity);

            // Set current datetime for version
            latestVersion.Version = DateUtil.GetCurrentDate();

            // Create latest version
            _context.Set<TEntityVersion>().Add(latestVersion);

            if (isAutoSave)
                _context.SaveChanges();
        }
    }
}
