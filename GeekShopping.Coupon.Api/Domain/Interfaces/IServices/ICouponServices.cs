using GeekShopping.Coupon.Api.Domain.Dto;

namespace GeekShopping.Coupon.Api.Domain.Interfaces.IServices
{
    public interface ICouponServices
    {
        Task<CouponDto> GetCouponByCode(string couponCode);
        Task<CouponDto> Save(CouponDto dto);
    }
}
