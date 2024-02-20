using System.Collections.Generic;

namespace GeekShopping.Cart.Api.Domain.Dto
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailDto> CartDetails { get; set; }
    }
}
