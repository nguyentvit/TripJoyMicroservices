using BuildingBlocks.Behaviors;
using BuildingBlocks.Messaging.MassTransit;
using FluentValidation;
using NotificationUser.SignalR.Data;
using NotificationUser.SignalR.Data.Repository;
using NotificationUser.SignalR.Extensions;
using NotificationUser.SignalR.Hubs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")!);
});

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis")!;
});

builder.Services.AddSignalR();

builder.Services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.Decorate<IUserRepository, CachedUserRepository>();

builder.Services.AddScoped<IPlanRepository, PlanRepository>();
builder.Services.Decorate<IPlanRepository, CachedPlanRepository>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
builder.Services.AddMessageBroker(builder.Configuration, Assembly.GetExecutingAssembly());

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

await app.InitializeDatabaseAsync();

app.UseCors("AllowAllOrigins");

app.MapControllers();

app.MapHub<NotificationHub>("notification-hub");

app.Run();
