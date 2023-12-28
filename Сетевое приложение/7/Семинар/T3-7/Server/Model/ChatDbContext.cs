using ModelDBLib;
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
        public DbSet<UserDB> Users { get; set; }
        public DbSet<MessageDB> Messages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies().UseNpgsql("Host=localhost;Username=postgres;Password=example;Database=ChatDb");
    }
}



