using GeekShopping.Order.Api.Configs.Settings;
using GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages.Send;
using GeekShopping.OrderAPI.Messages;
using Microsoft.Extensions.Options;

namespace GeekShopping.Order.Api.Domain.Services.Messages.Send
{
    public class PaymentSendMsgServices : RabbitMqSenderServices<PaymentMsgDto>, IPaymentSendMsgServices
    {
        public PaymentSendMsgServices(IOptions<AppSettingsRabbitMq> serviceSettings) : base(serviceSettings)
        {
        }
    }
}
