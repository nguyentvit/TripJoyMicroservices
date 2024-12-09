﻿using BuildingBlocks.Exceptions.Handler;
using Carter;

namespace Chat.API
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

            services.AddCarter();
            services.AddExceptionHandler<CustomExceptionHandler>();
            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.UseCors("AllowAllOrigins");

            app.MapCarter();

            app.UseExceptionHandler(options => { });

            return app;
        }
    }
}
