using GeekShopping.IdentityServer.Configs;
using GeekShopping.IdentityServer.Infra.Data.Context;
using GeekShopping.IdentityServer.Model;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySqlContext _mySqlContext;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySqlContext mySqlContext, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _mySqlContext = mySqlContext;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {

            //INSERT ADMIN IN DATABASE

            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result == null)
            {
                _role.CreateAsync(new IdentityRole(IdentityConfiguration.Admin)).GetAwaiter().GetResult();

                var admin = new ApplicationUser()
                {
                    UserName = "geekshopping-admin",
                    Email = "geekshopping-admin@geekshopping.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+55 11 111111111",
                    Name = "Rafael Fernandes da Cunha"
                };

                _user.CreateAsync(admin, "Q!W@e3r4").GetAwaiter().GetResult();

                _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

                var admClaims = _user.AddClaimsAsync(admin, new Claim[]
                {
                new Claim(JwtClaimTypes.Name, admin.Name),
                new Claim(JwtClaimTypes.GivenName, admin.Name),
                new Claim(JwtClaimTypes.FamilyName, admin.Name),
                new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin)

                }).Result;
            }




            //INSERT CLIENT IN DATABASE

            if (_role.FindByNameAsync(IdentityConfiguration.Client).Result == null)
            {
                _role.CreateAsync(new IdentityRole(IdentityConfiguration.Client)).GetAwaiter().GetResult();

                var client = new ApplicationUser()
                {
                    UserName = "geekshopping-client",
                    Email = "geekshopping-client@geekshopping.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+55 11 111111111",
                    Name = "Rafael Fernandes da Cunha"
                };

                _user.CreateAsync(client, "Q!W@e3r4").GetAwaiter().GetResult();

                _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

                var clientClaims = _user.AddClaimsAsync(client, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, client.Name),
                    new Claim(JwtClaimTypes.GivenName, client.Name),
                    new Claim(JwtClaimTypes.FamilyName, client.Name),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client)

                }).Result;
            }

        }
    }
}
