using LocationAttraction.Grpc;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TravelPlan.Application.Data;
using TravelPlan.Application.Grpc;
using TravelPlan.Infrastructure.Data;
using TravelPlan.Infrastructure.Data.Interceptors;
using TravelPlan.Infrastructure.Grpc;

namespace TravelPlan.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database");

            services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
            services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
                options.UseSqlServer(connectionString);
            });

            services.AddGrpcClient<LocationAttractionProtoService.LocationAttractionProtoServiceClient>(options =>
            {
                options.Address = new Uri(configuration["GrpcSettings:LocationUrl"]!);
            });

            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<ILocationGrpcService, LocationGrpcService>();
            return services;
        }

    }
}
