using GeekShopping.Payment.Api.Domain.Dto.Messages;
using System.Security.Cryptography;

namespace GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send
{
    public interface IPaymentSendMsgServices : IRabbitMqSenderMsgServices<PaymentProcessConsumerMsgDto>
    {
        void SendMessagePaymentUpdate(PaymentProcessResultSendMsgDto baseMessage, string queueName);
    }
}
