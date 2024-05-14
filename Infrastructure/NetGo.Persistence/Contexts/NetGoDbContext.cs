using Microsoft.EntityFrameworkCore;
using NetGo.Domain.Entities;

namespace NetGo.Persistence.Contexts
{
    public class NetGoDbContext : DbContext
    {
        public DbSet<Body> Bodies { get; set; }
        public DbSet<H1> H1s { get; set; }
        public DbSet<P> Ps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configurations.GetString("ConnectionStrings:SQLite"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Body>().HasKey(x => x.Id);
            modelBuilder.Entity<Body>().HasMany(b => b.Elements);

            base.OnModelCreating(modelBuilder);
        }
    }
}
