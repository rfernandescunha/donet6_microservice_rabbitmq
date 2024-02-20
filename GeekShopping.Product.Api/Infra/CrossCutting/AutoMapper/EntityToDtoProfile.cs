using AutoMapper;
using GeekShopping.Product.Api.Domain.Dto;
using GeekShopping.Product.Api.Domain.Entities;

namespace GeekShopping.Product.Api.Infra.CrossCutting.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {

            CreateMap<ProductDto, Domain.Entities.Product>().ReverseMap();


        }
    }
}
