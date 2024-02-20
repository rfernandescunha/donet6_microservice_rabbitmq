using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;

namespace GeekShopping.Web.Clients
{
    public static class InjectionApiClientService
    {
        public static void AddApiClientServiceConfig(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //serviceCollection.AddHttpClient<IProductServices, ProductServices>().ConfigureHttpClient((sProvider, httpCliente) =>
            //{
            //    var url = sProvider.GetRequiredService<IOptions<UrlConfigs>>().Value.ProductApi;

            //    httpCliente.BaseAddress = url;
            //    httpCliente.Timeout = TimeSpan.FromMinutes(5);

            //});


            serviceCollection.AddHttpClient<IProductApiService, ProductApiService>(c => c.BaseAddress = new Uri(configuration.GetSection("ServicesUrl").GetSection("ProductApi").Value));

            serviceCollection.AddHttpClient<ICartApiService, CartApiService>(c => c.BaseAddress = new Uri(configuration.GetSection("ServicesUrl").GetSection("CartApi").Value));

            serviceCollection.AddHttpClient<ICouponApiService, CouponApiService>(c => c.BaseAddress = new Uri(configuration.GetSection("ServicesUrl").GetSection("CouponApi").Value));

        }
    }
}