using HRIS.Domain.Interfaces.Repositories;
using HRIS.Infrastructure.DataAccess.Database;
using HRIS.Infrastructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRIS.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Get connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("MigrationDb");

            // Add database context
            services.AddDbContext<HRISDbContext>(options => options.UseSqlServer(connectionString));

            // Add repositories
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Add logger
            services.AddLogging();

            return services;
        }
    }
}
