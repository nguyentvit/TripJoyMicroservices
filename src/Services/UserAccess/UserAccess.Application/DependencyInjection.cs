using BuildingBlocks.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BuildingBlocks.Messaging.MassTransit;
using Microsoft.Extensions.Configuration;
using BuildingBlocks.Interfaces;
using BuildingBlocks.Services;

namespace UserAccess.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(LoggingBehavior<,>));
            });

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());
            services.AddSingleton<IS3Service, S3Service>();
            return services;
        }
    }
}
