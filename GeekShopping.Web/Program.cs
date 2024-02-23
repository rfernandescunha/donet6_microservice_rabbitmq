using GeekShopping.Web.Configs;
using GeekShopping.Web.Configs.Settings;
using GeekShopping.Web.Infra.Ioc;
using Microsoft.AspNetCore.Authentication;

IConfiguration configuration;

var builder = WebApplication.CreateBuilder(args);

configuration = builder.Configuration;


builder.Services.AddOptions();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(x => x.SerializerOptions.IncludeFields = true);

builder.Services.Configure<AppSettingsServicesUrl>(configuration.GetSection("ServicesUrl"));


builder.Services.AddApiClientServiceConfig(configuration);


// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddAuthenticationConfig(configuration);



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
