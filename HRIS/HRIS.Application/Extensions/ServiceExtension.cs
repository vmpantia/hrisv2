﻿using HRIS.Application.Services;
using HRIS.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HRIS.Application.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
