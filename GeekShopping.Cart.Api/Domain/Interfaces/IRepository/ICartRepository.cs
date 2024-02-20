namespace GeekShopping.Cart.Api.Repository
{
    public interface ICartRepository
    {
        Task<Domain.Entities.Cart> FindByUserId(string userId);
        Task<Domain.Entities.Cart> Save(Domain.Entities.Cart cart);
        Task<Domain.Entities.Cart> Update(Domain.Entities.Cart cart);
        Task<bool> Remove(long cartDetailsId);
        Task<bool> ApplyCoupon(string userId, string couponCode);
        Task<bool> RemoveCoupon(string userId);
        Task<bool> Clear(string userId);

        Task<bool> CartHeaderExist(string UserId);
    }
}
