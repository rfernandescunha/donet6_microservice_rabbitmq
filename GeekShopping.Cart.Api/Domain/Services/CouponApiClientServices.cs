using GeekShopping.Cart.Api.Domain.Interfaces.IServices;
using GeekShopping.CartAPI.Data.ValueObjects;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GeekShopping.Cart.Api.Domain.Services
{
    public class CouponApiClientServices : ICouponApiClientServices
    {
        private readonly HttpClient _client;

        public CouponApiClientServices(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CouponDto> GetCouponByCode(string couponCode, string token)
        {
            //"api/v1/coupon"
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.GetAsync($"/api/v1/coupon/{couponCode}");
            
            var content = await response.Content.ReadAsStringAsync();
            
            if (response.StatusCode != HttpStatusCode.OK) 
                return new CouponDto();

            return JsonSerializer.Deserialize<CouponDto>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
