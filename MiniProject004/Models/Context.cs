using Microsoft.EntityFrameworkCore;

namespace MiniProject004.Models
{
    public class Context : DbContext
    {
        public DbSet<Flower> Flowers { get; set; }
        public Context(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
