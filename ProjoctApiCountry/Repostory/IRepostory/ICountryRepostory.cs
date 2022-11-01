using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Repostory.IRepostory
{
    public interface ICountryRepostory
    {
        Task<Countrys> Add(Countrys country);
        
        Task<IEnumerable<Countrys>> GetAll();

        Task<Countrys> Update( int id, Countrys country);

        Task<Countrys> Delete(int id);
        
        Task<Countrys> GetId(int id);



    }
}
