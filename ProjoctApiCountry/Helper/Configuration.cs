using AutoMapper;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Helper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Region, RegionDTO>().ReverseMap();
        }

        
    }
}
