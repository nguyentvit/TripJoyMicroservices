namespace UserAccess.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCarter();

            services.AddExceptionHandler<CustomExceptionHandler>();

            services.AddHealthChecks();
            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();

            app.UseExceptionHandler(options => { });

            app.UseHealthChecks("/health");

            return app;
        }
    }
}
