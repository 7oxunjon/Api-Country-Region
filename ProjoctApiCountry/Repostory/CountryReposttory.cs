using FluentNHibernate.Conventions.Inspections;
using Microsoft.EntityFrameworkCore;
using ProjoctApiCountry.Context;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Repostory.IRepostory;

namespace ProjoctApiCountry.Repostory
{
    public class CountryReposttory : ICountryRepostory
    {
        protected readonly AppDbContext dbContext;

        public CountryReposttory(AppDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<Country> Add(Country country)
        {
            await dbContext.countries.AddAsync(country);
            await dbContext.SaveChangesAsync();
            return country;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await dbContext.countries.ToListAsync();
        }

        public async Task<Country> Update(int id, Country country)
        {
            var coun = await dbContext.countries.FindAsync(id);
            if (coun == null) await dbContext.countries.AddAsync(country);
            else dbContext.Entry(coun).CurrentValues.SetValues(country);
            dbContext.SaveChanges();
            return country;

        }
        public async Task<Country> Delete(int id)
        {
           var res = await dbContext.countries.FirstOrDefaultAsync(x => x.Id == id);
            if(res != null)
            {
                dbContext.countries.Remove(res);
                await dbContext.SaveChangesAsync();
                return res;
            }
            return null;
        }

        public async Task<Country> GetId(int id)
        {
            return await dbContext.countries.FirstAsync(c => c.Id == id);
            
        }
    }
}
