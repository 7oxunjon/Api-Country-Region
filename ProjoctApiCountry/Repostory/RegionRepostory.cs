using FluentNHibernate.Utils;
using Microsoft.EntityFrameworkCore;
using ProjoctApiCountry.Context;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Repostory.IRepostory;

namespace ProjoctApiCountry.Repostory
{
    public class RegionRepostory : IRegionRepostory
    {
        private readonly AppDbContext dbContext;

        public RegionRepostory(AppDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Region> Add(Region region)
        {
           await dbContext.regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
            
        }

        public async Task<IEnumerable<Region>> GetAll()
        {
            
            return  await dbContext.regions.ToListAsync();
        }

        public async Task<Region> Update(int id, Region region)
        {
            var con = await dbContext.regions.FindAsync(id);
            if (con == null) await dbContext.regions.AddAsync(region);
            else dbContext.Entry(con).CurrentValues.SetValues(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
    }

}
