using GeekShopping.Order.Api.Domain.Interfaces.Repository;
using GeekShopping.Order.Api.Infra.Data.Context;
using GeekShopping.Order.Api.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeekShopping.Order.Api.Infra.Ioc
{
    public static class InjectionRepository
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {


            //Pega a Conexao do arquivo lauch.json
            serviceCollection.AddDbContext<MySqlContext>(options => options.UseMySql(
                                                                                        configuration.GetSection("MySqlConfiguration").GetSection("ConnectionString").Value,
                                                                                        new MySqlServerVersion(new Version(8, 0, 36))));


            //serviceCollection.AddScoped<IOrderRepository, OrderRepository>();




            var builder = new DbContextOptionsBuilder<MySqlContext>();
            builder.UseMySql(configuration.GetSection("MySqlConfiguration").GetSection("ConnectionString").Value, new MySqlServerVersion(new Version(8, 0, 36)));

            serviceCollection.AddSingleton(new OrderRepository(builder.Options));





        }
    }
}
