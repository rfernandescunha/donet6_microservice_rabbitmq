using GeekShopping.Cart.Api.Domain.Dto.Cart;
using GeekShopping.Cart.Api.Domain.Dto.Messages;
using GeekShopping.Cart.Api.Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Cart.Api.Controllers.v1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CartController : ControllerBase
    {
        private ICartServices _services;
        

        public CartController(ICartServices services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<IActionResult> FindById(string id)
        {
            var cart = await _services.FindByUserId(id);

            if (cart == null)
                return BadRequest("cart not found.");

            return Ok(cart);
        }

        [Authorize]
        [HttpPost("add-cart")]
        public async Task<IActionResult> Post([FromBody] CartDto dto)
        {
            if (dto == null) 
                return BadRequest("product is required.");

            var result = await _services.SaveOrUpdate(dto);

            return Ok(result);
        }

        [Authorize]
        [HttpPut("update-cart")]
        public async Task<IActionResult> UpdateCart([FromBody] CartDto vo)
        {
            var cart = await _services.Update(vo);

            if (cart == null) 
                return NotFound();

            return Ok(cart);
        }

        [Authorize]
        [HttpDelete("remove-cart/{id}")]
        public async Task<IActionResult> RemoveCart(int id)
        {
            var status = await _services.Remove(id);

            if (!status) 
                return BadRequest();

            return Ok(status);
        }

        [Authorize]
        [HttpPost("apply-coupon")]
        public async Task<IActionResult> ApplyCoupon([FromBody]CartDto dto)
        {
            var response = await _services.ApplyCoupon(dto.CartHeader.UserId, dto.CartHeader.CouponCode);

            if (!response)
                return BadRequest("coupon not found.");

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("remove-coupon/{userId}")]
        public async Task<IActionResult> RemoveCoupon(string userId)
        {
            var response = await _services.RemoveCoupon(userId);

            if (!response)
                return BadRequest("coupon not found.");

            return Ok(response);
        }


        [Authorize]
        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutHeaderMsgDto dto)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var cart = await _services.CheckOut(dto, token);

            if (cart == null)
                return BadRequest("cart not found.");

            return Ok(cart);
        }
    }
}
