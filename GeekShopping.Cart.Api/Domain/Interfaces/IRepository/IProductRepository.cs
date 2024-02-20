namespace GeekShopping.Cart.Api.Domain.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<bool>Existe(long Id);
        Task<Domain.Entities.Product> Save(Entities.Product product);
    }
}
