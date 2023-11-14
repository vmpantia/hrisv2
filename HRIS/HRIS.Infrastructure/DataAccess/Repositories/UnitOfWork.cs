using AutoMapper;
using HRIS.Domain.Interfaces.Repositories;
using HRIS.Domain.Models.Entities;
using HRIS.Infrastructure.DataAccess.Database;
using System.Diagnostics.Contracts;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HRISDbContext _context;
        private readonly IMapper _mapper;
        private IConfigRepository _config;
        private IBaseRepository<Employee> _employee;
        private IBaseRepository<Contact> _contact;
        private IBaseRepository<Address> _address;
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

        public void Save() =>
            _context.SaveChanges();
    }
}
