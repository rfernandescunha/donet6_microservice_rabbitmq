﻿namespace GeekShopping.Product.Api.Domain.Dto
{
    public class ProductDto
    {
        public long  Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
    }
}
