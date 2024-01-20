using Microsoft.EntityFrameworkCore;
using T4_1.Model;

namespace Server.Db.Model
{
    internal class ProductsDbContext : DbContext
    {
        public ProductsDbContext()
        {
        }
        public ProductsDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=ProductsDb");
    }
}