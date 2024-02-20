using AutoMapper;

namespace GeekShopping.Cart.Api.Infra.CrossCutting.AutoMapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Coupon.Api.Domain.Dto.CouponDto,Coupon.Api.Domain.Entities.Coupon>().ReverseMap();
        }
    }
}
