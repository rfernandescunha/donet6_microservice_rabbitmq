using AutoMapper;

namespace GeekShopping.Cart.Api.Infra.CrossCutting.AutoMapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<Coupon.Api.Domain.Entities.Coupon, Coupon.Api.Domain.Dto.CouponDto>().ReverseMap();
        }
    }
}
