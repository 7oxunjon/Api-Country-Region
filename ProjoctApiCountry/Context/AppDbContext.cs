using Microsoft.EntityFrameworkCore;
using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        
        public DbSet<Country> countries { get; set; }
        
        public DbSet<Region> regions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Region>().
                HasOne(p => p.Country).
                WithMany(p => p.Regions).
                HasForeignKey(p => p.CountryId);
        }
    }
}
