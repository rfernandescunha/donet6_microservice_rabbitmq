using System.Collections.Generic;

namespace GeekShopping.Coupon.Api.Domain.Dto
{
    public class CouponDto
    {
        public long Id { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
