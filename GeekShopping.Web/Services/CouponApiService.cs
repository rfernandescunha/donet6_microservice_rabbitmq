using GeekShopping.Web.Models.Coupon;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class CouponApiService : ICouponApiService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/coupon";

        public CouponApiService(HttpClient client)
        {
            _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<CouponViewModel> GetCouponByCode(string couponCode, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"{BasePath}/{couponCode}");

            return await response.ReadContentAs<CouponViewModel>();
        }
    }
}
