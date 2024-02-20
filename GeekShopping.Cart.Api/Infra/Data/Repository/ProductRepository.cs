using GeekShopping.Card.Api.Infra.Data.Context;
using GeekShopping.Cart.Api.Domain.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Cart.Api.Infra.Data.Repository
{
    public class ProductRepository: IProductRepository
    {
        private readonly MySqlContext _context;

        public ProductRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<bool>Existe(long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            return product != null;
        }

        public async Task<Domain.Entities.Product> Save(Domain.Entities.Product cart)
        {
                
            _context.Products.Add(cart);
                
            await _context.SaveChangesAsync();
            
            return cart;
        }
    }
}
