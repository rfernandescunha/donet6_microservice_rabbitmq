using AutoMapper;
using GeekShopping.Coupon.Api.Domain.Interfaces.IServices;
using GeekShopping.Coupon.Api.Repository;
using GeekShopping.Coupon.Api.Domain.Dto;

namespace GeekShopping.Coupon.Api.Domain.Services
{
    public class CouponServices : ICouponServices
    {
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public CouponServices(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode)
        {
            try
            {
                var result = await _couponRepository.GetCouponByCode(couponCode);

                return _mapper.Map<CouponDto>(result);                

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<CouponDto> Save(CouponDto dto)
        {
            var obj = _mapper.Map<Entities.Coupon>(dto);

            var result = await _couponRepository.Save(obj);

            return _mapper.Map<CouponDto>(result);
        }
    }
}
