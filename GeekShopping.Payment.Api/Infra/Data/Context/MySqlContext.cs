
using GeekShopping.Payment.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.Payment.Api.Infra.Data.Context
{

    public class MySqlContext : DbContext
    {
        public MySqlContext() { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        public DbSet<OrderDetail> OderDetails { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }

    }
}
