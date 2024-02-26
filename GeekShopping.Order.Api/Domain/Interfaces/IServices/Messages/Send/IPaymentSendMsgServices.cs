using GeekShopping.Order.Api.Domain.Dto.Messages;

namespace GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages.Send
{
    public interface IPaymentSendMsgServices : IRabbitMqSenderMsgServices<PaymentMsgDto>
    {
    }
}
