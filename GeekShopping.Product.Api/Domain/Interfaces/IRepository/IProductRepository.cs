namespace GeekShopping.Product.Api.Domain.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Entities.Product>> FindAll();
        Task<Entities.Product> FindById(long Id);
        Task<Entities.Product> Create(Entities.Product product);
        Task<Entities.Product> Update(Entities.Product product);
        Task<bool> Delete(long Id);
    }
}
