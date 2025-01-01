using BuildingBlocks.Data.Interceptors;
using BuildingBlocks.Interfaces;
using BuildingBlocks.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PostManagement.Application.Data;
using PostManagement.Infrastructure.Data;

namespace PostManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            var environment = configuration["ASPNETCORE_ENVIRONMENT"];

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            if (environment == "Development")
            {
                services.AddHttpClient<IUserAccessService, UserAccessService>(client =>
                {
                    client.BaseAddress = new Uri("http://localhost:5192");
                });
            }

            else
            {
                services.AddHttpClient<IUserAccessService, UserAccessService>(client =>
                {
                    client.BaseAddress = new Uri("http://useraccess.api:8080");
                });
            }

            return services;
        }
    }
}
