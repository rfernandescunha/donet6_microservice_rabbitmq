﻿
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Cart.Api.Domain.Dto.Cart
{
    public class CartHeaderDto
    {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string CouponCode { get; set; }
    }
}
