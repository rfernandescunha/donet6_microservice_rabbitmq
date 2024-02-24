using GeekShopping.OrderAPI.Messages;

namespace GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages
{
    public interface IPaymentSendMsgServices: IRabbitMqSenderMsgServices<PaymentMsgDto>
    {
    }
}
