using AutoMapper;
using HRIS.Domain.Models.Entities;

namespace HRIS.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IMapper Mapper { get; }
        IBaseRepository<Employee> Employee { get; }
        void Save();
    }
}