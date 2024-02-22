using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GeekShopping.Order.Api.Configs
{
    public static class ConfigureSwagger
    {
        public static void AddSwaggerGenConfig(this IServiceCollection services)
        {
            services.AddVersionedApiExplorer(opt => {

                opt.GroupNameFormat = "'v'VVV";
                opt.SubstituteApiVersionInUrl = true;

            }).AddApiVersioning(opt => {

                opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.ReportApiVersions = true;

            });

            var apiProviderDescription = services.BuildServiceProvider().GetService<IApiVersionDescriptionProvider>();

            services.AddSwaggerGen(
                opt =>
                {
                    foreach (var descriptions in apiProviderDescription.ApiVersionDescriptions)
                    {
                        opt.SwaggerDoc(
                                        descriptions.GroupName,
                                        new OpenApiInfo()
                                        {
                                            Title = "GeekShopping Order Api",
                                            Version = descriptions.ApiVersion.ToString(),
                                            Contact = new OpenApiContact
                                            {
                                                Name = "Rafael F Cunha",
                                                Email = "rafa_fernandes_cunha@hotmail.com"
                                            }
                                        });
                    }

                    var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);

                    opt.IncludeXmlComments(xmlCommentsFullPath);

                    opt.EnableAnnotations();

                    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                    {
                        Description = @"Enter 'Bearer' [space] and your token !",
                        Name = "Authorization",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Scheme = "Bearer"
                    });

                    opt.AddSecurityRequirement(new OpenApiSecurityRequirement {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                    });
                });


        }

        public static void AddUseSwaggerConfig(this IApplicationBuilder app, IApiVersionDescriptionProvider apiVersionDescriptionProvider)
        {
            app.UseSwagger()
                            .UseSwaggerUI(
                            opt =>
                            {
                                foreach (var descriptions in apiVersionDescriptionProvider.ApiVersionDescriptions)
                                {
                                    opt.SwaggerEndpoint($"swagger/{descriptions.GroupName}/swagger.api.json", descriptions.GroupName.ToUpperInvariant());
                                    opt.RoutePrefix = "";
                                }


                            });
        }

    }
}
