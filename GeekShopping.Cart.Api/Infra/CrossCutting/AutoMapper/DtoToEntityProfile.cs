using AutoMapper;
using GeekShopping.Cart.Api.Domain.Dto;
using GeekShopping.Cart.Api.Domain.Entities;

namespace GeekShopping.Cart.Api.Infra.CrossCutting.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CartDetail, CartDetailDto>().ReverseMap();
            CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
            CreateMap<Domain.Entities.Cart, CartDto>().ReverseMap();
        }
    }
}
