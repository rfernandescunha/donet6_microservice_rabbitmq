using GeekShopping.Cart.Api.Domain.Dto.Messages;
using GeekShopping.MessageBus;

namespace GeekShopping.Cart.Api.Domain.Interfaces.IServices
{
    public interface IRabbitMqSenderServices
    {
        void SendMessage(CheckoutHeaderMsgDto baseMessage, string queueName);
    }
}
