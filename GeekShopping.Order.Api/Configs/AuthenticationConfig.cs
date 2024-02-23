using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GeekShopping.Order.Api.Configs
{
    public static class AuthenticationConfig
    {
        public static void AddAuthenticationConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", opt =>
            {
                opt.Authority = configuration.GetSection("ServicesUrl").GetSection("IdentityServer").Value;
                opt.TokenValidationParameters = new TokenValidationParameters { ValidateAudience = false };

            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "geek_shopping");
                });

            });
        }

    }
}
