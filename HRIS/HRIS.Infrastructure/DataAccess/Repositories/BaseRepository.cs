﻿using AutoMapper;
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

        public int Count(ISpecification<TEntity> specification)
        {
            IQueryable<TEntity> result = _table.AsNoTracking();

            if (specification.Expressions != null && specification.Expressions.Any())
                specification.Expressions.ForEach(exp => { result = result.Where(exp); });

            return result.Count();
        }

        public IEnumerable<TEntity> GetList(ISpecification<TEntity> specification)
        {
            IEnumerable<TEntity> result = specification.IsSplitQuery ? 
                                    _table.AsNoTracking()
                                          .AsSplitQuery() : _table.AsNoTracking();

            if (specification.Expressions != null && specification.Expressions.Any())
                specification.Expressions.ForEach(exp => { result = result.Where(exp.Compile()); });

            if (specification.OrderBy != null && specification.OrderBy.Any())
                specification.OrderBy.ForEach(exp => { result = result.OrderBy(exp.Compile()); });

            if (specification.OrderByDescending != null && specification.OrderByDescending.Any())
                specification.OrderByDescending.ForEach(exp => { result = result.OrderByDescending(exp.Compile()); });

            // Set number of filtered data before doing pagination
            specification.CountFilteredData = result.Count();

            if (specification.IsPaginationEnabled)
                result = result.Take(specification.Take).Skip(specification.Skip);

            if (specification.Includes != null && specification.Includes.Any())
                specification.Includes.ForEach(exp => { result = result.AsQueryable().Include(exp); });

            return result;
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
