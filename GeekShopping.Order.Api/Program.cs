//a variable to hold configuration
using GeekShopping.Order.Api.Configs;
using GeekShopping.Order.Api.Configs;
using GeekShopping.Order.Api.Configs.Settings;
using Microsoft.IdentityModel.Tokens;


IConfiguration configuration;

var builder = WebApplication.CreateBuilder(args);

configuration = builder.Configuration;


builder.Services.AddDependencyInjectionConfig(configuration);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddAuthenticationConfig(configuration);


builder.Services.AddSwaggerGenConfig();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
