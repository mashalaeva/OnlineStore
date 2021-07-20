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
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=OnlineMarketDb;Username=postgres;Password=1234");
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            InitializeCategoryBd(modelBuilder);
            InitializeManufacturerBd(modelBuilder);
            InitializeOrderBd(modelBuilder);
            InitializeProductBd(modelBuilder);
        }*/
/*
        private void InitializeCategoryBd(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new[]
                {
                    new Category
                    {
                        Id = 1, Name = "Шитье", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 2, Name = "Вязание", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 3, Name = "Вышивание", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 4, Name = "Бисероплетение", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 5, Name = "Товары для художников", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 6, Name = "Канцтовары", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 7, Name = "Бумага и бумажная продукция", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 8, Name = "Скрапбукинг", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 9, Name = "Декорирование", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 10, Name = "Игры и игрушки", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 11, Name = "Лепка и скульптура", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 12, Name = "Флористика", Description = "", Parent = null
                    },
                    new Category
                    {
                        Id = 13, Name = "Ткани", Description = "", Parent = Categories.Find(1)
                    },
                });
        }

        private void InitializeManufacturerBd(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
                new[]
                {
                    new Manufacturer()
                    {
                        Id = 1, Name = "", Country = "", MSRN = ""
                    },
                });
        }

        private void InitializeOrderBd(ModelBuilder modelBuilder)
        {
            *//*modelBuilder.Entity<Order>().HasData(
                new[]
                {
                    new Order()
                    {
                        Id = 1, Status = EStatus.Undefined, User = new User()
                    },
                });*//*
        }

        private void InitializeProductBd(ModelBuilder modelBuilder)
        {
            *//*modelBuilder.Entity<Product>().HasData(
                new[]
                {
                    new Product
                    {
                        Id = 1, Name = "", Category = new Category(), Manufacturer = new Manufacturer(),
                        Availability = true, PictureReference = ""
                    },
                    new Product
                    {
                        Id = 2, Name = "", Category = new Category(), Manufacturer = new Manufacturer(),
                        Availability = true, PictureReference = ""
                    }
                });*//*
        }*/
    }
}