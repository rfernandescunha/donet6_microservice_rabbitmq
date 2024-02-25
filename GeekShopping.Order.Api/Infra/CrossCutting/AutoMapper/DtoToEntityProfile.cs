using AutoMapper;
using GeekShopping.Order.Api.Domain.Dto;
using GeekShopping.Order.Api.Domain.Entities;

namespace GeekShopping.Order.Api.Infra.CrossCutting.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();
            

        }
    }
}
