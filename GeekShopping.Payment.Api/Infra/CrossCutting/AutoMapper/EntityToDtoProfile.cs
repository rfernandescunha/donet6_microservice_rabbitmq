using AutoMapper;

namespace GeekShopping.Payment.Api.Infra.CrossCutting.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            //CreateMap<OrderHeaderDto, OrderHeader>().ReverseMap();
            //CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();
        }
    }
}
