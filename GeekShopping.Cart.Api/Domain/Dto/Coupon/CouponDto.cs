﻿namespace GeekShopping.CartAPI.Data.ValueObjects
{
    public class CouponDto
    {
        public long Id { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountAmount { get; set; }
    }
}
