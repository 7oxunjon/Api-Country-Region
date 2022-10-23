using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Repostory.IRepostory
{
    public interface ICountryRepostory
    {
        Task<Country> Add(Country country);
        
        Task<IEnumerable<Country>> GetAll();

        Task<Country> Update( int id, Country country);

        Task<Country> Delete(int id);
        
        Task<Country> GetId(int id);



    }
}
