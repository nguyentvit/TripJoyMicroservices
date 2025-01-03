﻿using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using FluentEmail.Smtp;
using Identity.Infrastructure.Persistence;
using Identity.Infrastructure.Persistence.Repository;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace Identity.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.AddIdentity(configuration);
            services.AddEmailSender(configuration);
            services.AddRedis(configuration);
            services.AddAuth(configuration);

            services.AddHttpContextAccessor();
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddSingleton<IOTPService, OTPService>();
            services.AddSingleton<ITokenProvider, TokenProvider>();

            services.AddScoped<IOTPQueryRepository, OTPQueryRepository>();
            services.AddScoped<IOTPCommandRepository, OTPCommandRepository>();

            services.AddScoped<IOTPPwCommandRepository, OTPPwCommandRepository>();
            services.AddScoped<IOTPPwQueryRepository, OTPPwQueryRepository>();

            services.AddScoped<IApplicationUserQueryRepository, ApplicationUserQueryRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IPersistedGrantRepository, PersistedGrantRepository>();

            services.AddScoped<IPersistedGrantService, PersistedGrantService>();

            services.AddSingleton<IRefreshTokenHasher, RefreshTokenHasher>();

            services.AddSingleton<ISqlConnectionFactory>(provider =>
            {
                var connection = configuration.GetConnectionString("SqlConnection");
                return new SqlConnectionFactory(connection!);
            });

            return services;
        }
        public static IServiceCollection AddIdentity(
            this IServiceCollection services,
            ConfigurationManager configuration
            )
        {
            var environment = configuration["ASPNETCORE_ENVIRONMENT"];
            var connection = configuration.GetConnectionString("DefaultConnection");
            var migrationsAssembly = typeof(DependencyInjection).Assembly.GetName().FullName;

            var certPath = "";
            var keyPath = "";

            if (environment == "Development")
            {
                var baseDir = Directory.GetCurrentDirectory();
                certPath = Path.Combine(baseDir, "Certificates", "tls.crt");
                keyPath = Path.Combine(baseDir, "Certificates", "tls.key");
            }

            else if (environment == "Production")
            {
                certPath = Path.Combine("/etc/ssl/certs", "tls.crt");
                keyPath = Path.Combine("/etc/ssl/certs", "tls.key");
            }
            
            var cert = X509Certificate2.CreateFromPemFile(certPath, keyPath);

            services.AddDbContext<Persistence.IdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromMinutes(15);
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {

                // configure password
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // configure signin
                options.SignIn.RequireConfirmedEmail = true;
                options.SignIn.RequireConfirmedAccount = true;
                
            })
                .AddEntityFrameworkStores<IdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
                options.EmitStaticAudienceClaim = true;

            })
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = db =>
                        db.UseSqlServer(connection,
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = db =>
                    db.UseSqlServer(connection,
                    sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddAspNetIdentity<ApplicationUser>()
                .AddExtensionGrantValidator<TokenExchangeGrantValidator>()
                .AddProfileService<CustomProfileService>()
                .AddSigningCredential(cert)
                ;

            services.AddTransient<UserManager<ApplicationUser>, CustomUserManager>();
            services.AddTransient<IPasswordHasher<ApplicationUser>, CustomPasswordHasher<ApplicationUser>>();
            return services;
        }

        public static IServiceCollection AddEmailSender(this IServiceCollection services, ConfigurationManager configuration)
        {
            var smtpSettings = new SmtpSettings();
            configuration.Bind(SmtpSettings.SectionName, smtpSettings);
            services.AddSingleton(Options.Create(smtpSettings));

            var smtpClient = new SmtpClient(smtpSettings.Host, smtpSettings.Port)
            {
                Credentials = new NetworkCredential(smtpSettings.UserName, smtpSettings.Password),
                EnableSsl = true
            };

            ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

            services.AddFluentEmail(smtpSettings.FromEmail, smtpSettings.FromName)
               .AddSmtpSender(smtpClient)
               .AddRazorRenderer();

            return services;
        }

        public static IServiceCollection AddRedis(this IServiceCollection services, ConfigurationManager configuration)
        {
            var redisConfiguration = configuration.GetConnectionString("Redis");
            var options = ConfigurationOptions.Parse(redisConfiguration!);
            options.AbortOnConnectFail = false;

            if (true)
            {
                var connectionMultiplexer = ConnectionMultiplexer.Connect(options);
                services.AddSingleton<IConnectionMultiplexer>(connectionMultiplexer);
                services.AddStackExchangeRedisCache(options =>
                {
                    options.Configuration = redisConfiguration;
                });
                services.AddScoped<ITokenBlacklistService, RedisTokenBlacklistService>();
                services.AddScoped<ITokenWhitelistService, RedisTokenWhitelistService>();
                services.AddScoped<ISendOtpService, SendOtpService>();
            }

            return services;
        }
        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddAuthentication(
                options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }
            )
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.Authority = "http://localhost:5032";
                    options.RequireHttpsMetadata = false;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                }).AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = "54512677689-2fi560s0sleddn285cmaaa7vjr6fcrhl.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    options.AccessType = "offline";

                    //options.CallbackPath = new PathString("/gg/signin-google");

                    options.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/auth";
                    options.TokenEndpoint = "https://accounts.google.com/o/oauth2/token";
                    options.UserInformationEndpoint = "https://www.googleapis.com/oauth2/v3/userinfo";

                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");

                    options.SaveTokens = true;

                    options.Events.OnRedirectToAuthorizationEndpoint = context =>
                    {
                        var uriBuilder = new UriBuilder(context.RedirectUri);
                        var query = System.Web.HttpUtility.ParseQueryString(uriBuilder.Query);

                        query["access_type"] = "offline";
                        query["response_type"] = "code";
                        uriBuilder.Query = query.ToString();

                        context.Response.Redirect(uriBuilder.ToString());
                        return Task.CompletedTask;
                    };
                }).AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "http://localhost:5032";
                    options.RequireHttpsMetadata = false;
                    options.ClientId = "magic";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.CallbackPath = new PathString("/gg/signin-google");
                    options.SkipUnrecognizedRequests = true;
                });

            return services;
        }
    }
}
