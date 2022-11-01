using ProjoctApiCountry.Model.Mod;

namespace ProjoctApiCountry.Repostory.IRepostory
{
    public interface IRegionRepostory
    {
        Task<Regions> Add(Regions region);
        Task<IEnumerable<Regions>> GetAll();
        Task<Regions>Update(int id, Regions region);
        Task<Regions> Delete(int id);
        Task<Regions> Get(int id);
    }
 }
