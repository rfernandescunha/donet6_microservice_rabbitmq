using GeekShopping.Order.Api.Configs.Settings;
using GeekShopping.Order.Api.Domain.Interfaces.IServices.Messages;
using GeekShopping.OrderAPI.Messages;
using Microsoft.Extensions.Options;

namespace GeekShopping.Order.Api.Domain.Services.Messages
{
    public class PaymentSendMsgServices : RabbitMqSenderServices<PaymentMsgDto>, IPaymentSendMsgServices
    {
        public PaymentSendMsgServices(IOptions<AppSettingsRabbitMq> serviceSettings) : base(serviceSettings)
        {
        }
    }
}
