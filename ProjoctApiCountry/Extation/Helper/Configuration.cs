using AutoMapper;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Model.Mod;

namespace ProjoctApiCountry.Helper
{
    public class Configuration : Profile
    {
        public Configuration()
        {
            CreateMap<Countrys, CountryDTO>().ReverseMap();
            CreateMap<Regions, RegionDTO>().ReverseMap();
        }

        
    }
}
