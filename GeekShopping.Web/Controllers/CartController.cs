using GeekShopping.Web.Models.Cart;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiService _productaApiService;
        private readonly ICartApiService _cartApiService;
        private readonly ICouponApiService _couponApiService;

        public CartController(
                                IProductApiService productaApiService,
                                ICartApiService cartApiService,
                                ICouponApiService couponApiService)
        {
            _productaApiService = productaApiService;
            _cartApiService = cartApiService;
            _couponApiService = couponApiService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var response = await FindUserCart();

            return View(response);
        }

        [HttpPost]
        [ActionName("ApplyCoupon")]
        public async Task<IActionResult> ApplyCoupon(CartViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartApiService.ApplyCoupon(model, token);

            if (response)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ActionName("RemoveCoupon")]
        public async Task<IActionResult> RemoveCoupon()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartApiService.RemoveCoupon(userId, token);

            if (response)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartApiService.Remove(id, token);

            if (response)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            return View(await FindUserCart());
        }

        [HttpPost]
        [ActionName("Checkout")]
        public async Task<IActionResult> Checkout(CartViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var response = await _cartApiService.Checkout(model.CartHeader, token);

            if (response != null)
            {
                return RedirectToAction(nameof(Confirmation));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Confirmation()
        {
            return View();
        }

        private async Task<CartViewModel> FindUserCart()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var userId = User.Claims.Where(u => u.Type == "sub")?.FirstOrDefault()?.Value;

            var response = await _cartApiService.FindByUserId(userId, token);

            if (response?.CartHeader != null)
            {
                if (!string.IsNullOrEmpty(response.CartHeader.CouponCode))
                {
                    var coupon = await _couponApiService.GetCouponByCode(response.CartHeader.CouponCode, token);

                    if (coupon?.CouponCode != null)                    
                        response.CartHeader.DiscountAmount = coupon.DiscountAmount;
                    
                }
                foreach (var detail in response.CartDetails)
                {
                    response.CartHeader.PurchaseAmount += (detail.Product.Price * detail.Count);
                }
                response.CartHeader.PurchaseAmount -= response.CartHeader.DiscountAmount;
            }
            return response;
        }
    }
}
