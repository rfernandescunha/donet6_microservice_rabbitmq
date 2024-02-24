using GeekShopping.Cart.Api.Domain.Dto.Messages;

namespace GeekShopping.Cart.Api.Domain.Interfaces.IServices.Messages
{
    public interface IRabbitMqSenderMsgServices<T> where T : class
    {
        void SendMessage(T baseMessage, string queueName);
    }
}
