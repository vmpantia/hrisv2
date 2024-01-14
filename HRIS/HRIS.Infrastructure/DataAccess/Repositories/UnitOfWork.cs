using AutoMapper;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Models.Entities;
using HRIS.Infrastructure.DataAccess.Database;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRISDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private IConfigRepository _config;
        private IBaseRepository<Employee> _employee;
        private IBaseRepository<Contact> _contact;
        private IBaseRepository<Address> _address;
        private IAppLogRepository _appLog;

        public UnitOfWork(HRISDbContext context, IMapper mapper, ILogger<UnitOfWork> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public IMapper Mapper => _mapper;

        #region Custom Repository
        public IConfigRepository Config
        {
            get
            {
                if (_config == null)
                    _config = new ConfigRepository(_context, _mapper);

                return _config;
            }
        }

        public IAppLogRepository AppLog
        {
            get
            {
                if (_appLog == null)
                    _appLog = new AppLogRepository(_context, _mapper, _logger);

                return _appLog;
            }
        }
        #endregion

        #region Common Repository
        public IBaseRepository<Employee> Employee
        {
            get
            {
                if (_employee == null)
                    _employee = new BaseRepository<Employee>(_context, _mapper);

                return _employee;
            }
        }

        public IBaseRepository<Contact> Contact
        {
            get
            {
                if (_contact == null)
                    _contact = new BaseRepository<Contact>(_context, _mapper);

                return _contact;
            }
        }

        public IBaseRepository<Address> Address
        {
            get
            {
                if (_address == null)
                    _address = new BaseRepository<Address>(_context, _mapper);

                return _address;
            }
        }
        #endregion

        public void Save() =>
            _context.SaveChanges();
    }
}
