using AutoMapper;
using HRIS.Domain.Interfaces.Models;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Utils;
using HRIS.Infrastructure.DataAccess.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HRISDbContext _context;
        private readonly IMapper _mapper;
        private readonly DbSet<TEntity> _table;
        public BaseRepository(HRISDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _table = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll() =>
            _table.AsNoTracking()
                  .AsQueryable();

        public IQueryable<TEntity> GetByExpression(Expression<Func<TEntity, bool>> expression) =>
            _table.Where(expression)
                  .AsNoTracking()
                  .AsQueryable();

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

        public void CreateVersion<TEntityVersion>(TEntity entity, bool isAutoSave = false) where TEntityVersion : class, IEntityVersion
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
