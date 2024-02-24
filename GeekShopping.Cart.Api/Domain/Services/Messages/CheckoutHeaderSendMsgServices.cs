using GeekShopping.Cart.Api.Configs.Settings;
using GeekShopping.Cart.Api.Domain.Dto.Messages;
using GeekShopping.Cart.Api.Domain.Interfaces.IServices.Messages;
using Microsoft.Extensions.Options;

namespace GeekShopping.Cart.Api.Domain.Services.Messages
{
    public class CheckoutHeaderSendMsgServices : RabbitMqSenderMsgServices<CheckoutHeaderMsgDto>, ICheckoutHeaderSendMsgServices
    {
        public CheckoutHeaderSendMsgServices(IOptions<AppSettingsRabbitMq> serviceSettings) : base(serviceSettings)
        {
        }
    }
}
