using GeekShopping.Cart.Api.Domain.Messages;
using GeekShopping.MessageBus;

namespace GeekShopping.Cart.Api.RabbitMqSender
{
    public interface IRabbitMqSender
    {
        void SendMessage(CheckoutHeaderMsgDto baseMessage, string queueName);
    }
}
