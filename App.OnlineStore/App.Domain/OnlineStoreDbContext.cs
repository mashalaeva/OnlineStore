using Microsoft.EntityFrameworkCore;

namespace App.Domain
{
    public class OnlineStoreDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductsInOrder> ProductsInOrders { get; set; }
        public DbSet<User> Users { get; set; }

        public OnlineStoreDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OnlineShopDb;Username=postgres;Password=1234");
        }
    }
}