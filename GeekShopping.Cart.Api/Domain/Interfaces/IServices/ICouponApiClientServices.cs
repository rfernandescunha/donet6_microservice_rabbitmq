using GeekShopping.CartAPI.Data.ValueObjects;

namespace GeekShopping.Cart.Api.Domain.Interfaces.IServices
{
    public interface ICouponApiClientServices
    {
        Task<CouponDto> GetCouponByCode(string couponCode, string token);
    }
}
