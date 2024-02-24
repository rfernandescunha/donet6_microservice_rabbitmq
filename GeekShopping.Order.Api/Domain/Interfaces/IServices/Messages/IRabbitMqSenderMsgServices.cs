namespace GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages
{
    public interface IRabbitMqSenderMsgServices<T> where T : class
    {
        void SendMessage(T baseMessage, string queueName);
    }
}
