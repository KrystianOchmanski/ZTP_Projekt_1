using Microsoft.EntityFrameworkCore;
using ZTP_Projekt_1.Domain;

namespace ZTP_Projekt_1.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<BlockedName> BlockedNames { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}
