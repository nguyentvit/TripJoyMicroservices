using UserAccess.API;
using UserAccess.Application;
using UserAccess.Infrastructure;
using UserAccess.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddInfrastructure(builder.Configuration)
    .AddApiService(builder.Configuration);

System.Net.ServicePointManager.ServerCertificateValidationCallback =
    (sender, certificate, chain, sslPolicyErrors) => true;

var app = builder.Build();

app.UseApiServices();

await app.InitializeDatabaseAsync();

app.Run();
