using FluentNHibernate.Utils;
using Microsoft.EntityFrameworkCore;
using ProjoctApiCountry.Context;
using ProjoctApiCountry.Model.Mod;
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

        public async Task<Regions> Add(Regions region)
        {
           await dbContext.regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
            
        }


        public async Task<IEnumerable<Regions>> GetAll()
        {
            
            return  await dbContext.regions.ToListAsync();
        }

        public async Task<Regions> Update(int id, Regions region)
        {
            var con = await dbContext.regions.FindAsync(id);
            if (con == null) await dbContext.regions.AddAsync(region);
            else dbContext.Entry(con).CurrentValues.SetValues(region);
            await dbContext.SaveChangesAsync();
            return region;
        }
        public async Task<Regions> Delete(int id)
        {
            var con = await dbContext.regions.FirstOrDefaultAsync(p=>p.Id==id);
            if (con != null)
            {
                dbContext.regions.Remove(con);
                await dbContext.SaveChangesAsync();
                return con;
            }
            return null;
        }

        public async Task<Regions> Get(int id)
        {
            return  await dbContext.regions.FirstAsync(p => p.Id == id);
        }
    }

}
