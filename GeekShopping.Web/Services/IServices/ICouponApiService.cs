using GeekShopping.Web.Models.Coupon;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICouponApiService
    {
        Task<CouponViewModel> GetCouponByCode(string couponCode, string token);
    }
}
