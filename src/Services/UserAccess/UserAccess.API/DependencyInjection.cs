﻿namespace UserAccess.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity(configuration);

            services.AddAuthorization();

            services.AddCarter();

            services.AddExceptionHandler<CustomExceptionHandler>();

            services.AddHealthChecks();
            return services;
        }
        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseExceptionHandler(options => { });

            app.UseHealthChecks("/health");

            return app;
        }
        private static IServiceCollection AddIdentity(this IServiceCollection services, IConfiguration configuration)
        {

            //var serverIp = Environment.GetEnvironmentVariable("SERVER_IP");
            //if (!string.IsNullOrEmpty(serverIp))
            //{
            //    configuration["IpServerAuthentication"] = $"{serverIp}";
            //}

            configuration["IpServerAuthentication"]= "http://192.168.30.120:6200";

            var ipAuthentication = configuration.GetValue<string>("IpServerAuthentication");
            var assembly = typeof(Program).Assembly;

            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
            };
            var client = new HttpClient(handler);
            var response = client.GetStringAsync($"{ipAuthentication}/.well-known/openid-configuration/jwks").GetAwaiter().GetResult();
            var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(response)!.Keys;

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.Authority = ipAuthentication;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidIssuer = ipAuthentication,
                        ValidateAudience = true,
                        ValidAudience = $"{ipAuthentication}/resources",
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKeyResolver = (token, securityToken, kid, validationParameters) =>
                        {
                            return keys;
                        }
                    };
                })
                .AddCookie()
                .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
                {
                    options.ClientId = "54512677689-2fi560s0sleddn285cmaaa7vjr6fcrhl.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

                    options.AccessType = "offline";

                    options.CallbackPath = new PathString("/signin-google");

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
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = ipAuthentication;
                    options.ClientId = "web-client";
                    options.ClientSecret = "web-client-secret";
                    options.ResponseType = "code";
                    options.SaveTokens = true;
                    options.CallbackPath = "/signin-google";
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("email");
                    options.RequireHttpsMetadata = false;
                });

            return services;
        }
    }
}
