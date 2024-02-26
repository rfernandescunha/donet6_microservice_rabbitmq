using GeekShopping.Order.Api.Domain.Entities;
using GeekShopping.Order.Api.Domain.Interfaces.Repository;
using GeekShopping.Order.Api.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GeekShopping.Order.Api.Infra.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DbContextOptions<MySqlContext> _context;

        public OrderRepository(DbContextOptions<MySqlContext> context)
        {
            _context = context;
        }

        public async Task<bool> Save(OrderHeader header)
        {
            if(header == null) 
                return false;

            await using var _db = new MySqlContext(_context);
            
            _db.OrderHeaders.Add(header);
            await _db.SaveChangesAsync();
            
            return true;
        }

        public async Task<bool> PaymentStatusUpdate(long orderHeaderId, bool status)
        {
            await using var _db = new MySqlContext(_context);
            
            var header = await _db.OrderHeaders.FirstOrDefaultAsync(o => o.Id == orderHeaderId);
            
            if (header != null)
            {
                header.PaymentStatus = status;
                await _db.SaveChangesAsync();
            };

            return true;
        }
    }
}
