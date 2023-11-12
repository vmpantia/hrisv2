using AutoMapper;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Models.Entities;
using HRIS.Infrastructure.DataAccess.Database;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRISDbContext _context;
        private readonly IMapper _mapper;
        private IConfigRepository _config;
        private IBaseRepository<Employee> _employee;
        public UnitOfWork(HRISDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IMapper Mapper { get { return _mapper; } }

        public IConfigRepository Config
        {
            get
            {
                if (_config == null)
                    _config = new ConfigRepository(_context, _mapper);

                return _config;
            }
        }

        public IBaseRepository<Employee> Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new BaseRepository<Employee>(_context, _mapper);

                return _employee;
            }
        }

        public void Save() =>
            _context.SaveChanges();
    }
}
