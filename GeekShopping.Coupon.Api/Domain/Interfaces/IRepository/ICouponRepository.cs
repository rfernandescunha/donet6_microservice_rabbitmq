namespace GeekShopping.Coupon.Api.Repository
{
    public interface ICouponRepository
    {
        Task<Domain.Entities.Coupon> GetCouponByCode(string couponCode);
        Task<Domain.Entities.Coupon> Save(Domain.Entities.Coupon ent);
    }
}
