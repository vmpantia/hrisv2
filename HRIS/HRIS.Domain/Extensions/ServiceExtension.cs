using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRIS.Domain.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
