using Duende.IdentityServer.EntityFramework.DbContexts;
using Identity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Common.Data
{
    public static class Extensions
    {
        public static async Task<IApplicationBuilder> UseMigration(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var identityContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
            var configurationDbContext = scope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
            var persistedGrantDbContext = scope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>();

            // Đợi cho các migration hoàn thành
            await identityContext.Database.MigrateAsync();
            await configurationDbContext.Database.MigrateAsync();
            await persistedGrantDbContext.Database.MigrateAsync();

            return app;
        }
    }
}
