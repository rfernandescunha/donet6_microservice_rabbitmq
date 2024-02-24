using GeekShopping.Cart.Api.Domain.Interfaces.IServices;
using GeekShopping.Cart.Api.Domain.Interfaces.IServices.Messages;
using GeekShopping.Cart.Api.Domain.Services;
using GeekShopping.Cart.Api.Domain.Services.Messages;

namespace GeekShopping.Card.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICartServices, CartServices>();


            serviceCollection.AddSingleton(typeof(IRabbitMqSenderMsgServices<>), typeof(RabbitMqSenderMsgServices<>));

            serviceCollection.AddSingleton<ICheckoutHeaderSendMsgServices, CheckoutHeaderSendMsgServices>(); 

        }
    }
}