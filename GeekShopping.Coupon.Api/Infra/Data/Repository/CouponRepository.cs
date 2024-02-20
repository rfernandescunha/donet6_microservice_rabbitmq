using GeekShopping.Coupon.Api.Infra.Data.Context;
using GeekShopping.Coupon.Api.Repository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Coupon.Api.Infra.Data.Repository
{
    public class CouponRepository : ICouponRepository
    {
        private readonly MySqlContext _context;

        public CouponRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<Coupon.Api.Domain.Entities.Coupon> GetCouponByCode(string couponCode)
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.CouponCode == couponCode);
            return coupon;
        }

        public async Task<Domain.Entities.Coupon> Save(Domain.Entities.Coupon ent)
        {
            _context.Add(ent);
            await _context.SaveChangesAsync();

            return ent;
        }
    }
}
