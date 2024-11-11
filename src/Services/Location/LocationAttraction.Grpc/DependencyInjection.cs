using BuildingBlocks.Exceptions.Handler;
using LocationAttraction.Grpc.Services;

namespace LocationAttraction.Grpc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiService(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddGrpc(options =>
            {
                options.Interceptors.Add<ExceptionHandlingInterceptor>();
            });

            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapGrpcService<LocationAttractionService>();

            return app;
        }
    }
}
