using GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages;
using GeekShopping.Order.Api.Domain.Services.Messages;
using Microsoft.Extensions.DependencyInjection;

namespace GeekShopping.Order.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(IRabbitMqSenderMsgServices<>), typeof(RabbitMqSenderServices<>));

            serviceCollection.AddSingleton<IPaymentSendMsgServices, PaymentSendMsgServices>();

            serviceCollection.AddHostedService<RabbitMqConsumerMsgServices>();

        }
    }
}