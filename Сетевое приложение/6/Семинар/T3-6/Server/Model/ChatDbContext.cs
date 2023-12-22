using Microsoft.EntityFrameworkCore;

namespace Server
{
    internal class ChatDbContext : DbContext
    {
        public ChatDbContext()
        {
        }
        public ChatDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = true;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=ChatDb");
    }
}



