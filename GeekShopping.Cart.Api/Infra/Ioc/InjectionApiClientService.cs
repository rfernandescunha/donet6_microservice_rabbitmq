using GeekShopping.Cart.Api.Configs.Settings;
using GeekShopping.Cart.Api.Domain.Interfaces.IServices;
using GeekShopping.Cart.Api.Domain.Services;
using Microsoft.Extensions.Options;

namespace GeekShopping.Cart.Api.Infra.Ioc
{
    public static class InjectionApiClientService
    {
        public static void Register(this IServiceCollection serviceCollection)
        {

            // I build a new service provider from the services collection
            using ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            var urlCouponApi = serviceProvider.GetRequiredService<IOptions<AppSettingsServicesUrl>>().Value.CouponApi;


            serviceCollection.AddHttpClient<ICouponApiClientServices, CouponApiClientServices>(c => c.BaseAddress = urlCouponApi);

        }
    }
}