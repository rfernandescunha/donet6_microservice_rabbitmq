
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Card.Api.Infra.Data.Context
{

    public class MySqlContext : DbContext
    {
        public MySqlContext() { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<Cart.Api.Domain.Entities.Product> Products { get; set; }
        public DbSet<Cart.Api.Domain.Entities.CartDetail> CartDetails { get; set; }
        public DbSet<Cart.Api.Domain.Entities.CartHeader> CartHeaders { get; set; }

    }
}
