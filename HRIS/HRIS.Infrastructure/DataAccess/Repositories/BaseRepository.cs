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

        public IEnumerable<TEntity> GetAll(ISpecification<TEntity> specification = null)
        {
            var result = _table.AsNoTracking();

            if (specification.isPagingEnabled)
                result = result.Take(specification.Take).Skip(specification.Skip);

            if (specification.OrderBy != null)
                result = result.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending != null)
                result = result.OrderByDescending(specification.OrderByDescending);

            return specification.Includes.Aggregate(result, (current, include) => current.Include(include));
        }

        public IEnumerable<TEntity> GetByExpression(ISpecification<TEntity> specification)
        {
            var result = _table.Where(specification.Criteria).AsNoTracking();

            if (specification.isPagingEnabled)
                result = result.Take(specification.Take).Skip(specification.Skip);

            if (specification.OrderBy != null)
                result = result.OrderBy(specification.OrderBy);

            if (specification.OrderByDescending != null)
                result = result.OrderByDescending(specification.OrderByDescending);

            return specification.Includes.Aggregate(result, (current, include) => current.Include(include));
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
