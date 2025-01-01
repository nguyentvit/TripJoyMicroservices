using PostManagement.API;
using PostManagement.Application;
using PostManagement.Infrastructure;
using PostManagement.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApiServices(builder.Configuration);

var app = builder.Build();

await app.InitializeDatabaseAsync();

app.UseApiServices();

app.Run();
