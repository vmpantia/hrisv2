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
            bool isExist = false;

            if (specification.Expressions == null || !specification.Expressions.Any())
                throw new Exception("Specification expression cannot be NULL when checking if the data exist.");

            foreach (var data in specification.Expressions)
            {
                if (isExist)
                    return isExist;

                isExist = _table.Any(data);
            }

            return isExist;
        }

        public IEnumerable<TEntity> GetList(ISpecification<TEntity> specification)
        {
            var result = _table.AsNoTracking();

            if (specification.Expressions != null && specification.Expressions.Any())
                specification.Expressions.ForEach(data => { result = _table.Where(data); });

            if (specification.OrderBy != null && specification.OrderBy.Any())
                specification.OrderBy.ForEach(data => { result = _table.OrderBy(data); });

            if (specification.OrderByDescending != null && specification.OrderByDescending.Any())
                specification.OrderByDescending.ForEach(data => { result = _table.OrderByDescending(data); });

            if (specification.IsPaginationEnabled)
                result = result.Take(specification.Take).Skip(specification.Skip);

            return specification.Includes.Aggregate(result, (current, include) => current.Include(include));
        }

        public TEntity GetOne(ISpecification<TEntity> specification)
        {
            if (specification.Expressions == null || !specification.Expressions.Any())
                throw new Exception("Specification expression cannot be NULL when getting one record.");

            return GetList(specification).First();
        }

        public void Create(TEntity entity) =>
            _table.Add(entity);

        public void Update(TEntity entity) =>
            _table.Update(entity);

        public void Version<TEntityVersion>(TEntity entity) where TEntityVersion : class, IEntityVersion
        {
            var latestVersion = _mapper.Map<TEntityVersion>(entity);

            // Set current datetime for version
            latestVersion.Version = DateUtil.GetCurrentDate();

            // Create latest version
            _context.Set<TEntityVersion>().Add(latestVersion);
        }
    }
}
