using GeekShopping.Web.Clients;
using Microsoft.AspNetCore.Authentication;

IConfiguration configuration;

var builder = WebApplication.CreateBuilder(args);

configuration = builder.Configuration;


//builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(x => x.SerializerOptions.IncludeFields = true);

//builder.Services.Configure<UrlConfigs>(configuration.GetSection("urlApis"));


builder.Services.AddApiClientServiceConfig(configuration);


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = "Cookies";
    opt.DefaultChallengeScheme = "oidc";

}).AddCookie("Cookies", c=> c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
  .AddOpenIdConnect("oidc", opt=>
    {
        opt.Authority = configuration.GetSection("ServicesUrl").GetSection("IdentityServer").Value;
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



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
