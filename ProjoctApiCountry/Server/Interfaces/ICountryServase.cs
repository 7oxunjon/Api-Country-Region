using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Server
{
    public interface ICountryServase
    {
        Task<CountryDTO> Insert(CountryDTO country);
        
        Task<IEnumerable<Country>> GetAll();
        
        Task<CountryDTO> Update( int id, CountryDTO country);

        Task<Country> Delete(int id);

        Task<Country> GetId(int id);



    }
}
