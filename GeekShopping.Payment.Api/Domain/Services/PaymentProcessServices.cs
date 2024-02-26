using GeekShopping.Payment.Api.Domain.Dto;
using GeekShopping.Payment.Api.Domain.Dto.Messages;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices;
using GeekShopping.Payment.Api.Domain.Interfaces.IServices.Messages.Send;

namespace GeekShopping.Payment.Api.Domain.Services
{
    public class PaymentProcessServices : IPaymentProcessServices
    {
        private readonly IPaymentSendMsgServices _paymentSendMsgServices;

        public PaymentProcessServices(IPaymentSendMsgServices paymentSendMsgServices)
        {
            _paymentSendMsgServices = paymentSendMsgServices;
        }

        public void PaymentProcess(PaymentDto dto)
        { 
            _paymentSendMsgServices.SendMessagePaymentUpdate(ProcessMsg(dto), "orderpaymentprocessresultqueue");
        }

        private PaymentProcessResultSendMsgDto ProcessMsg(PaymentDto vo)
        {
            var paymentUpdate = new PaymentProcessResultSendMsgDto()
            {
                Status = true,
                OrderId = vo.OrderId,
                Email = vo.Email,

            };

            return paymentUpdate;
        }
    }
}
