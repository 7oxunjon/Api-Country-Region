using Microsoft.EntityFrameworkCore.Internal;
using ProjoctApiCountry.Repostory;
using ProjoctApiCountry.Repostory.IRepostory;
using ProjoctApiCountry.Server;

namespace ProjoctApiCountry.Extation
{
    public static class MiddleExtations
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddTransient<ICountryServase,CountryService>();
            services.AddTransient<IRegionServer,RegionServer>();
        }

        public static void AddRepostory(this IServiceCollection services)
        {
            services.AddTransient<ICountryRepostory, CountryReposttory>();
            services.AddTransient<IRegionRepostory, RegionRepostory>();
        }

        
    }
}
