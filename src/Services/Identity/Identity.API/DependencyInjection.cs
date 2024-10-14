using BuildingBlocks.Exceptions.Handler;
using Identity.API.Common.Attributes;
using Identity.API.Common.Errors;
using Identity.API.Common.Mapping;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Identity.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddMappings();

            services.AddExceptionHandler<CustomExceptionHandler>();
            services.AddSingleton<ProblemDetailsFactory, ProblemDetailFactory>();
            services.AddTransient<IAuthorizationHandler, TokenBlacklistHandler>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
