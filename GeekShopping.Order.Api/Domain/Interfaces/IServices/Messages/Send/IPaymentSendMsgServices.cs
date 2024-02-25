using GeekShopping.OrderAPI.Messages;

namespace GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages.Send
{
    public interface IPaymentSendMsgServices : IRabbitMqSenderMsgServices<PaymentMsgDto>
    {
    }
}
