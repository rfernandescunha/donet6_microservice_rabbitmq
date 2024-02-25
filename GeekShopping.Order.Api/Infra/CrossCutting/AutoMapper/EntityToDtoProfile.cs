using AutoMapper;
using GeekShopping.Order.Api.Domain.Dto;
using GeekShopping.Order.Api.Domain.Entities;

namespace GeekShopping.Order.Api.Infra.CrossCutting.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<OrderHeaderDto, OrderHeader>().ReverseMap();
            CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();
        }
    }
}
