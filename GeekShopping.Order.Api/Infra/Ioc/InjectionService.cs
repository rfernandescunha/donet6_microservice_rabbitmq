using GeekShopping.Order.Api.Domain.Interfaces.IServices;
using GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages.Send;
using GeekShopping.Order.Api.Domain.Services;
using GeekShopping.Order.Api.Domain.Services.Messages.Consumer;
using GeekShopping.Order.Api.Domain.Services.Messages.Send;
using Microsoft.Extensions.DependencyInjection;

namespace GeekShopping.Order.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(IRabbitMqSenderMsgServices<>), typeof(RabbitMqSenderServices<>));

            serviceCollection.AddSingleton<IOrderServices, OrderServices>();
            serviceCollection.AddSingleton<IPaymentSendMsgServices, PaymentSendMsgServices>();

            serviceCollection.AddHostedService<CheckoutConsumerMsgServices>();
            serviceCollection.AddHostedService<PaymentConsumerMsgServices>();
        }
    }
}