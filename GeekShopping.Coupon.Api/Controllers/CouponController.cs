using GeekShopping.Coupon.Api.Domain.Dto;
using GeekShopping.Coupon.Api.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CouponA.Api.Controllers
{

    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CouponController : ControllerBase
    {
        private ICouponServices _services;

        public CouponController(ICouponServices services)
        {
            _services = services ?? throw new
                ArgumentNullException(nameof(services));
        }

        [HttpGet("{couponCode}")]
        [Authorize]
        public async Task<IActionResult> GetCouponByCode(string couponCode)
        {
            var coupon = await _services.GetCouponByCode(couponCode);
            if (coupon == null) return NotFound();
            return Ok(coupon);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] CouponDto dto)
        {
            var coupon = await _services.Save(dto);
            if (coupon == null) return NotFound();
            return Ok(coupon);
        }
    }
}
