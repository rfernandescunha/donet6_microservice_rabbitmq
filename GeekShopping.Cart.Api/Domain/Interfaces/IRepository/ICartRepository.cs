namespace GeekShopping.Cart.Api.Domain.Interfaces.IRepository
{
    public interface ICartRepository
    {
        Task<Entities.Cart> FindByUserId(string userId);
        Task<Entities.Cart> Save(Entities.Cart cart);
        Task<Entities.Cart> Update(Entities.Cart cart);
        Task<bool> Remove(long cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> Clear(string userId);

        Task<bool> CartHeaderExist(string UserId);
    }
}
