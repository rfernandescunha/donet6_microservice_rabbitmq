using GeekShopping.Web.Models;
using GeekShopping.Web.Models.Cart;
using System.Threading.Tasks;

namespace GeekShopping.Web.Services.IServices
{
    public interface ICartApiService
    {
        Task<CartViewModel> FindByUserId(string userId, string token);
        Task<CartViewModel> Add(CartViewModel cart, string token);
        Task<CartViewModel> Update(CartViewModel cart, string token);
        Task<bool> Remove(long cartId, string token);

        Task<bool> ApplyCoupon(CartViewModel cart, string token);
        Task<bool> RemoveCoupon(string userId, string token);
        Task<bool> ClearCart(string userId, string token);

        Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token);
     }
}
