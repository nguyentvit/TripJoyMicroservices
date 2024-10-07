using UserAccess.API;
using UserAccess.Application;
using UserAccess.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//System.Net.ServicePointManager.ServerCertificateValidationCallback =
//    (sender, certificate, chain, sslPolicyErrors) => true;

builder.Services
    .AddApplicationServices()
    .AddInfrastructure(builder.Configuration)
    .AddApiService(builder.Configuration);


var app = builder.Build();

app.UseApiServices();

app.Run();
