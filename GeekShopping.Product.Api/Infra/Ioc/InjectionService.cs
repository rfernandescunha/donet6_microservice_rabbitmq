

using GeekShopping.Product.Api.Domain.Interfaces.IServices;
using GeekShopping.Product.Api.Domain.Services;

namespace GeekShopping.Product.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IProductServices, ProductServices>();

        }
    }
}