using GeekShopping.Payment.Api.Domain.Dto;

namespace GeekShopping.Payment.Api.Domain.Interfaces.IServices
{
    public interface IPaymentProcessServices
    {
        void PaymentProcess(PaymentDto dto);
    }
}
