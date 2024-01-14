using AutoMapper;
using HRIS.Domain.Models.Entities;
using HRIS.Infrastructure.DataAccess.Repositories;

namespace HRIS.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IMapper Mapper { get; }
        IConfigRepository Config { get; }
        IAppLogRepository AppLog { get; }
        IBaseRepository<Employee> Employee { get; }
        IBaseRepository<Contact> Contact { get; }
        IBaseRepository<Address> Address { get; }
        void Save();
    }
}