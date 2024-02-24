using GeekShopping.Cart.Api.Domain.Dto.Messages;

namespace GeekShopping.Cart.Api.Domain.Interfaces.IServices.Messages
{
    public interface ICheckoutHeaderSendMsgServices:IRabbitMqSenderMsgServices<CheckoutHeaderMsgDto>
    {
        void SendMessage(CheckoutHeaderMsgDto baseMessage, string queueName);
    }
}
