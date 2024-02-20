using GeekShopping.Web.Models.Product;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;

namespace GeekShopping.Web.Services
{
    public class ProductApiService : IProductApiService
    {
        private readonly HttpClient _httpClient;
        public const string basePath = "api/v1/product";

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductViewModel> Create(ProductViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PostAsyncAsJson(basePath, model);

            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<ProductViewModel> Update(ProductViewModel model, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.PutAsyncAsJson(basePath, model);

            return await response.ReadContentAs<ProductViewModel>();
        }

        public async Task<bool> Delete(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.DeleteAsync($"{basePath} / {id}");

            return await response.ReadContentAs<bool>();
        }

        public async Task<IEnumerable<ProductViewModel>> FindAll()
        {
            var response = await _httpClient.GetAsync(basePath);

            return await response.ReadContentAs<IEnumerable<ProductViewModel>>();
        }

        public async Task<IEnumerable<ProductViewModel>> FindAll(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync(basePath);

            return await response.ReadContentAs<IEnumerable<ProductViewModel>>();
        }

        public async Task<ProductViewModel> FindById(long id, string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _httpClient.GetAsync($"{basePath}/{id}");

            return await response.ReadContentAs<ProductViewModel>();
        }


    }
}
