using AutoMapper;
using GeekShopping.Product.Api.Domain.Dto;
using GeekShopping.Product.Api.Domain.Entities;

namespace GeekShopping.Product.Api.Infra.CrossCutting.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<Domain.Entities.Product, ProductDto>().ReverseMap();
        }
    }
}
