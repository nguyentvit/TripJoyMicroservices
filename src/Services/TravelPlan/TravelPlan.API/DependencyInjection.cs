using BuildingBlocks.Exceptions.Handler;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace TravelPlan.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            services.AddCarter();

            services.AddExceptionHandler<CustomExceptionHandler>();

            services.AddHealthChecks()
                .AddSqlServer(configuration.GetConnectionString("Database")!);

            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AllowAllOrigins");
            app.MapCarter();

            app.UseExceptionHandler(options => { });

            app.UseHealthChecks("/health",
                new HealthCheckOptions
                {
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });

            return app;
        }
    }
}
