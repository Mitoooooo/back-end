using Application.IServices;
using Application.Services;
using Application;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.IRepositories;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructuresService(this IServiceCollection services, string databaseConnection)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<ICurrentTime, CurrentTime>();

            services.AddScoped<ISportTypeRepository, SportTypeRepository>();

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(databaseConnection, sqlServerOptions =>
                {
                    // Enable retry on transient failures
                    sqlServerOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,        // Number of retry attempts
                        maxRetryDelay: TimeSpan.FromSeconds(30), // Delay between retries
                        errorNumbersToAdd: null  // List of error codes to retry on (null means all transient errors)
                    );
                });

                // Enable sensitive data logging
                options.EnableSensitiveDataLogging();
            });
            return services;
        }
    }
}
