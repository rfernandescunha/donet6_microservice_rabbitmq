using GeekShopping.Cart.Api.Domain.Interfaces.IServices;
using GeekShopping.Cart.Api.Domain.Services;
using GeekShopping.Cart.Api.RabbitMqSender;

namespace GeekShopping.Card.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICartServices, CartServices>();

            serviceCollection.AddScoped<IRabbitMqSender, RabbitMqSender>();

        }
    }
}