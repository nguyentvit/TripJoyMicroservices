using Duende.IdentityServer.EntityFramework.DbContexts;
using Duende.IdentityServer.EntityFramework.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation()
        .AddInfrastructure(builder.Configuration)
        .AddApplication();
}
var app = builder.Build();

app.UseCors("AllowFrontendLocalhost");

InitializeDatabase(app);


app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "2.0");
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseIdentityServer();
app.UseAuthentication();

app.MapControllers();

app.Run();


void InitializeDatabase(IApplicationBuilder app)
{
    using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
    {
        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            roleManager.CreateAsync(new IdentityRole("Admin")).Wait();
        }

        if (!roleManager.RoleExistsAsync("Customer").Result)
        {
            roleManager.CreateAsync(new IdentityRole("Customer")).Wait();
        }

        serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

        var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        context.Database.Migrate();

        context.Clients.RemoveRange(context.Clients);
        context.IdentityResources.RemoveRange(context.IdentityResources);
        context.ApiScopes.RemoveRange(context.ApiScopes);
        context.SaveChanges();

        if (!context.Clients.Any())
        {
            foreach (var client in IdentityConfig.Get)
            {
                context.Clients.Add(client.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.IdentityResources.Any())
        {
            foreach (var resource in IdentityConfig.IdentityResources)
            {
                context.IdentityResources.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }

        if (!context.ApiScopes.Any())
        {
            foreach (var resource in IdentityConfig.ApiScopes)
            {
                context.ApiScopes.Add(resource.ToEntity());
            }
            context.SaveChanges();
        }
    }
}
