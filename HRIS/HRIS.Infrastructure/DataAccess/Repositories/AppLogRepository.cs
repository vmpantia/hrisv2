using AutoMapper;
using HRIS.Domain.Models.Entities;
using HRIS.Domain.Models.Enums;
using HRIS.Infrastructure.DataAccess.Database;
using Microsoft.Extensions.Logging;

namespace HRIS.Infrastructure.DataAccess.Repositories
{
    public class AppLogRepository : BaseRepository<AppLog>, IAppLogRepository
    {
        private readonly ILogger _logger;
        public AppLogRepository(HRISDbContext context, IMapper mapper, ILogger logger) : base(context, mapper)
        {
            _logger = logger;
        }

        public void LogMessage(AppLog log)
        {
            try
            {
                // Get log level
                var logLevel = log.Type switch
                {
                    AppLogType.INFO => LogLevel.Information,
                    AppLogType.WARNING => LogLevel.Warning,
                    AppLogType.ERROR => LogLevel.Error,
                    _ => LogLevel.Critical,
                };

                // Log details in ILogger
                _logger.Log(logLevel, log.ToString());

                // Log details in database
                _table.Add(log);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Critical, $"{ex.Message} \n\n {log}");
            }
        }
    }
}
