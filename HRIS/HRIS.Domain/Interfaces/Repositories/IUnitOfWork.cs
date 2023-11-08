using HRIS.Domain.Models.Entities;

namespace HRIS.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IBaseRepository<Employee> Employee { get; }

        void Save();
    }
}