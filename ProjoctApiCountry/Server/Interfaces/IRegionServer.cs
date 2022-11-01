using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model.Mod;

namespace ProjoctApiCountry.Server;

public interface IRegionServer
{
    Task<RegionDTO>Inter(RegionDTO region);
    Task<IEnumerable<Regions>> GetAll();
    Task<RegionDTO> Update(int id, RegionDTO region);
    Task<Regions> Delete(int id);
    Task<Regions> Get(int id);
}
