﻿using GeekShopping.Cart.Api.Domain.Dto.Product;

namespace GeekShopping.Cart.Api.Domain.Dto.Cart
{
    public class CartDetailDto
    {
        public long Id { get; set; }
        public long CartHeaderId { get; set; }
        public CartHeaderDto CartHeader { get; set; }
        public long ProductId { get; set; }
        public ProductDto Product { get; set; }

        public int Count { get; set; }
    }
}
