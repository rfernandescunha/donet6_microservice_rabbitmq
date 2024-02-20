
using GeekShopping.IdentityServer.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Infra.Data.Context
{

    public class MySqlContext : IdentityDbContext<ApplicationUser>
    {
        public MySqlContext() { }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }

        //public DbSet<Product> Products { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //SEED DATA
        //    // id's 1 e 2 insert into with api
        //    // Execute Seed Data into powershell (1- dotnet ef add migrations AddSeedDataProduct / 2- dotnet ef database update) 
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 3, Name = "Capacete Darth Vader", Price = new decimal(350.99), Description = "Capacete do Dather Vader", CategoryName = "Brinquedo", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/3_vader.jpg" });
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 4, Name= "Boneco Storm Tropper", Price = 150, Description = "Boneco Storm Tropper", CategoryName = "Brinquedo", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/4_storm_tropper.jpg"});
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 5, Name= "Camiseta 100% Gamer", Price = new decimal(45.99), Description = "Camiseta 100% Gamer", CategoryName = "Camiseta", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/5_100_gamer.jpg"});
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 6, Name= "Camiseta SpaceX", Price = 40, Description = "Camiseta SpaceX", CategoryName = "Camiseta", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/6_spacex.jpg" });
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 7, Name= "Camiseta Coffee", Price = new decimal(35.99), Description = "Camiseta Coffee", CategoryName = "Camiseta", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/7_coffee.jpg"});
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 8, Name= "Blusa Cobra Kai", Price = 150, Description = "Blusa Cobra Kai", CategoryName = "Blusa", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/8_moletom_cobra_kay.jpg"});
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 9, Name= "Livro Star Talk", Price = 30, Description = "Livro Star Talk", CategoryName = "Livro", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/9_neil.jpg"});
        //    modelBuilder.Entity<Product>().HasData(new Product() { Id = 10, Name= "Milennium Falcon", Price = new decimal(250.99), Description = "Milennium Falcon", CategoryName = "Brinquedo", ImgUrl = "https://github.com/leandrocgsi/erudio-microservices-dotnet6/blob/main/ShoppingImages/10_milennium_falcon.jpg"});

        //}
    }
}
