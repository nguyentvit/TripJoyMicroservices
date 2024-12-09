using Chat.API;
using Chat.Infrastructure.Extensions;
using Chat.Application;
using Chat.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddApiService(builder.Configuration);

var app = builder.Build();

app.UseApiServices();

await app.InitializeDatabaseAsync();

app.Run();
