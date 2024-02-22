using GeekShopping.Web.Models.Cart;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;
using System.Reflection;

namespace GeekShopping.Web.Services
{
    public class CartApiService : ICartApiService
    {
        private readonly HttpClient _httpClient;
        public const string BasePath = "api/v1/cart";

        public CartApiService(HttpClient client)
        {
            _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindByUserId(string userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"{BasePath}/find-cart/{userId}");

            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<CartViewModel> Add(CartViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsyncAsJson($"{BasePath}/add-cart", model);

            return await response.ReadContentAs<CartViewModel>();
        }
        public async Task<CartViewModel> Update(CartViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PutAsJsonAsync($"{BasePath}/update-cart", model);

            return await response.ReadContentAs<CartViewModel>();
        }

        public async Task<bool> Remove(long cartId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync($"{BasePath}/remove-cart/{cartId}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentAs<bool>();
            else 
                throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> ApplyCoupon(CartViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsJsonAsync($"{BasePath}/apply-coupon", model);

            return await response.ReadContentAs<bool>();
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync($"{BasePath}/remove-coupon/{userId}");

            return await response.ReadContentAs<bool>();            
        }

        public async Task<CartHeaderViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsyncAsJson($"{BasePath}/checkout", cartHeader);
            
            return await response.ReadContentAs<CartHeaderViewModel>();

        }

        public async Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

    }
}
