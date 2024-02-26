using GeekShopping.Payment.Api.Domain.Interfaces.IServices;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send;
using GeekShopping.Payment.Api.Domain.Services;
using GeekShopping.Payment.Api.Domain.Services.Messages.Consumer;
using GeekShopping.Payment.Api.Domain.Services.Messages.Send;

namespace GeekShopping.Payment.Api.Infra.Ioc
{
    public static class InjectionService
    {
        public static void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton(typeof(IRabbitMqSenderMsgServices<>), typeof(RabbitMqSenderServices<>));

            serviceCollection.AddSingleton<IPaymentProcessServices, PaymentProcessServices>();
            serviceCollection.AddSingleton<IPaymentSendMsgServices, PaymentSendMsgServices>();

            serviceCollection.AddHostedService<PaymentConsumerMsgServices>();

        }
    }
}