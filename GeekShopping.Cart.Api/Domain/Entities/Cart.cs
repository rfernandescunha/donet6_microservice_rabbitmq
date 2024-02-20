using System.Collections.Generic;

namespace GeekShopping.Cart.Api.Domain.Entities
{
    public class Cart
    {
        public CartHeader CartHeader { get; set; }
        public IEnumerable<CartDetail> CartDetails { get; set; }
    }
}
