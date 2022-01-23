using Microsoft.EntityFrameworkCore;
using ProjectComplete.Models;

namespace ProjectComplete.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Collection> Collections {get;set;}
        public DbSet<Item> Items {get;set;}
    }
}
