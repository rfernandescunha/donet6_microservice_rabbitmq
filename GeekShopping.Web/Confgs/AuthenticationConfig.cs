using GeekShopping.Web.Configs.Settings;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace GeekShopping.Web.Configs
{
    public static class AuthenticationConfig
    {
        public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            // I build a new service provider from the services collection
            using ServiceProvider serviceProvider = services.BuildServiceProvider();

            var urlIdentityServer = serviceProvider.GetRequiredService<IOptions<AppSettingsServicesUrl>>().Value.IdentityServer;

            services.AddAuthentication(opt =>
            {
                opt.DefaultScheme = "Cookies";
                opt.DefaultChallengeScheme = "oidc";

            }).AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
              .AddOpenIdConnect("oidc", opt =>
              {
                  opt.Authority = urlIdentityServer;
                  opt.GetClaimsFromUserInfoEndpoint = true;
                  opt.ClientId = "geek_shopping";
                  opt.ClientSecret = "my_secret_here"; //Enviar para AppSettings
                  opt.ResponseType = "code";
                  opt.ClaimActions.MapJsonKey("role", "role", "role");
                  opt.ClaimActions.MapJsonKey("sub", "sub", "sub");
                  opt.TokenValidationParameters.NameClaimType = "name";
                  opt.TokenValidationParameters.RoleClaimType = "role";
                  opt.Scope.Add("geek_shopping");
                  opt.SaveTokens = true;

              });
        }

    }
}
