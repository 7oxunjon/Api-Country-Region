using AutoMapper;
using ProjoctApiCountry.Controllers;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model.Mod;
using ProjoctApiCountry.Repostory.IRepostory;
using ProjoctApiCountry.Server;

namespace ProjoctApiCountry.Server
{
    public class RegionServer : IRegionServer
    {
        private readonly IRegionRepostory regions;
        private readonly ILogger<RegionController> logger;
        private readonly IMapper mapper;

        public RegionServer(IRegionRepostory regions, ILogger<RegionController> logger, IMapper mapper)
        {
            this.regions = regions ?? throw new ArgumentNullException(nameof(regions));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public Task<IEnumerable<Regions>> GetAll()
        {
            return regions.GetAll();
        }

        public async Task<RegionDTO> Inter(RegionDTO regionDTO)
        {
            var region=mapper.Map<Regions>(regionDTO);
            return(mapper.Map<RegionDTO>(await regions.Add(region)));
            
            
        }

        public async Task<RegionDTO> Update(int id, RegionDTO regionDTO)
        {
            Regions region1 = mapper.Map<Regions>(regionDTO);
            region1.Id = id;
            return (mapper.Map<RegionDTO>(await regions.Update(id,region1)));
        }
        public async Task<Regions> Delete(int id)
        {
            var con = await regions.Get(id);
            return (mapper.Map<Regions>(await regions.Delete(id)));
        }

        public async Task<Regions> Get(int id)
        {
            return await regions.Get(id);   
        }
    }
}
