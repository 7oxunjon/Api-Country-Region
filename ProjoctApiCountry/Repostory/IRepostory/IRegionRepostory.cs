using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Repostory.IRepostory
{
    public interface IRegionRepostory
    {
        Task<Region> Add(Region region);
        Task<IEnumerable<Region>> GetAll();
        Task<Region>Update(int id, Region region);
    }
}
