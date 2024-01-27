using Microsoft.EntityFrameworkCore;
using T4_1.Model;

namespace Server.Db.Model
{
    internal class ProductsDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public ProductsDbContext()
        {
        }
        public ProductsDbContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
            _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Store> Stores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql(_config.GetValue<string>("ConnectionString"));
    }
}