using Microsoft.EntityFrameworkCore;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Model.Mod;

namespace ProjoctApiCountry.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        
        public DbSet<Countrys> countries { get; set; }
        
        public DbSet<Regions> regions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Regions>().
                HasOne(p => p.Country).
                WithMany(p => p.Regions).
                HasForeignKey(p => p.CountryId);
        }
    }
}
