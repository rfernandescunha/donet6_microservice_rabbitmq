
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Coupon.Api.Infra.Data.Context
{

    public class MySqlContext : DbContext
    {
        public MySqlContext() { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Coupon.Api.Domain.Entities.Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Domain.Entities.Coupon>().HasData(new Domain.Entities.Coupon
            {
                Id = 1,
                CouponCode = "ERUDIO_2022_10",
                DiscountAmount = 10
            });
            modelBuilder.Entity<Domain.Entities.Coupon>().HasData(new Domain.Entities.Coupon
            {
                Id = 2,
                CouponCode = "ERUDIO_2022_15",
                DiscountAmount = 15
            });
        }

    }
}
