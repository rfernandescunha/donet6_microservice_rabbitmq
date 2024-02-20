using GeekShopping.Cart.Api.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekShopping.Cart.Api.Domain.Entities
{
    [Table("cart_header")]
    public class CartHeader : BaseEntity
    {
        [Column("user_id")]
        public string UserId { get; set; }

        [Column("coupon_code")]
        public string CouponCode { get; set; }
    }
}
