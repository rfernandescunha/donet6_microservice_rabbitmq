using GeekShopping.Product.Api.Domain.Entities;
using GeekShopping.Product.Api.Domain.Interfaces.IRepository;
using GeekShopping.Product.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Product.Api.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MySqlContext _mySqlContext;

        public ProductRepository(MySqlContext mySqlContext)
        {
            _mySqlContext = mySqlContext;                
        }

        public async Task<Domain.Entities.Product> Create(Domain.Entities.Product product)
        {
            _mySqlContext.Add(product);
            await _mySqlContext.SaveChangesAsync();
            
            return product;
        }

        public async Task<bool> Delete(long Id)
        {
            var result = await _mySqlContext.Products.FirstOrDefaultAsync(x => x.Id == Id);
            
            if(result !=null)
            {
                _mySqlContext.Remove(result);
                await _mySqlContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> FindAll()
        {
            var result = await _mySqlContext.Products.ToListAsync();

            return result;
        }

        public async Task<Domain.Entities.Product> FindById(long Id)
        {
            var result = await _mySqlContext.Products.FirstOrDefaultAsync(x=> x.Id == Id) ?? new Domain.Entities.Product();

            return result;

        }

        public async Task<Domain.Entities.Product> Update(Domain.Entities.Product product)
        {
            _mySqlContext.Update(product);
            await _mySqlContext.SaveChangesAsync();

            return product;
        }
    }
}
