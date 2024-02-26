using GeekShopping.Payment.Api.Configs.Settings;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send;
using Microsoft.Extensions.Options;
using GeekShopping.Payment.Api.Domain.Dto.Messages;

namespace GeekShopping.Payment.Api.Domain.Services.Messages.Send
{
    public class PaymentSendMsgServices : RabbitMqSenderServices<PaymentProcessConsumerMsgDto>, IPaymentSendMsgServices
    {
        private readonly IOptions<AppSettingsRabbitMq> _serviceSettings;

        public PaymentSendMsgServices(IOptions<AppSettingsRabbitMq> serviceSettings) : base(serviceSettings)
        {
            _serviceSettings = serviceSettings;
        }

        public void SendMessagePaymentUpdate(PaymentProcessResultSendMsgDto baseMessage, string queueName)
        {
            var _senderMsgPaymentUpdate = new RabbitMqSenderServices<PaymentProcessResultSendMsgDto>(_serviceSettings);

            _senderMsgPaymentUpdate.SendMessage(baseMessage, queueName);
        }
    }
}
