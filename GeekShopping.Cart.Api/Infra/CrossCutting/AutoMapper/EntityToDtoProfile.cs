using AutoMapper;
using GeekShopping.Cart.Api.Domain.Dto.Cart;
using GeekShopping.Cart.Api.Domain.Dto.Product;
using GeekShopping.Cart.Api.Domain.Entities;

namespace GeekShopping.Cart.Api.Infra.CrossCutting.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {

            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CartDetailDto, CartDetail>().ReverseMap();
            CreateMap<CartHeaderDto, CartHeader>().ReverseMap();
            CreateMap<CartDto, Domain.Entities.Cart> ().ReverseMap();


        }
    }
}
