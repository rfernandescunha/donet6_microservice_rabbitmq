using System.Collections.Generic;

namespace GeekShopping.Cart.Api.Domain.Dto.Cart
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}
