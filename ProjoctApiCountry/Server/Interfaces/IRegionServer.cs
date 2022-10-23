using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Server;

public interface IRegionServer
{
    Task<RegionDTO>Inter(RegionDTO region);
    Task<IEnumerable<Region>> GetAll();
    Task<RegionDTO> Update(int id, RegionDTO region);
}
