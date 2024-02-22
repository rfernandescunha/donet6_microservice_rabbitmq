using GeekShopping.Cart.Api.Domain.Dto;
using GeekShopping.Cart.Api.Domain.Dto.Messages;

namespace GeekShopping.Cart.Api.Domain.Interfaces.IServices
{
    public interface ICartServices
    {
        Task<CartDto> FindByUserId(string userId);
        Task<CartDto> Save(CartDto cart);
        Task<CartDto> Update(CartDto cart);
        Task<CartDto> SaveOrUpdate(CartDto cart);
        Task<bool> Remove(long cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> Clear(string userId);

        Task<CartDto> CheckOut(CheckoutHeaderMsgDto dto);
    }
}
