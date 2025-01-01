using BuildingBlocks.Interfaces;
using BuildingBlocks.Services;
using Chat.Application.Data;
using Chat.Infrastructure.Data;
using Chat.Infrastructure.Data.Interceptors;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");
            var environment = configuration["ASPNETCORE_ENVIRONMENT"];

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });

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
