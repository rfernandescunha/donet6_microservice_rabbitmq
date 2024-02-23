using GeekShopping.Web.Configs.Settings;
using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.Extensions.Options;

namespace GeekShopping.Web.Infra.Ioc
{
    public static class InjectionApiClientService
    {
        public static void AddApiClientServiceConfig(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            using ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var urlProductApi = serviceProvider.GetRequiredService<IOptions<AppSettingsServicesUrl>>().Value.ProductApi;
            var urlCartApi = serviceProvider.GetRequiredService<IOptions<AppSettingsServicesUrl>>().Value.CartApi;
            var urlCouponApi = serviceProvider.GetRequiredService<IOptions<AppSettingsServicesUrl>>().Value.CouponApi;


            serviceCollection.AddHttpClient<IProductApiService, ProductApiService>(c => c.BaseAddress = urlProductApi);

            serviceCollection.AddHttpClient<ICartApiService, CartApiService>(c => c.BaseAddress = urlCartApi);

            serviceCollection.AddHttpClient<ICouponApiService, CouponApiService>(c => c.BaseAddress = urlCouponApi);

        }
    }
}