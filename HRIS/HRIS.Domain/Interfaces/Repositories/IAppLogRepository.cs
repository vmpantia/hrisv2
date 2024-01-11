using HRIS.Domain.Models.Entities;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public interface IAppLogRepository
    {
        void LogMessage(AppLog log);
    }
}