using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;

namespace ProjoctApiCountry.Server
{
    public interface ICountryServase
    {
        Task<CountryDTO> Insert(CountryDTO country);
        
        Task<IEnumerable<Countrys>> GetAll();
        
        Task<CountryDTO> Update( int id, CountryDTO country);

        Task<Countrys> Delete(int id);

        Task<Countrys> GetId(int id);



    }
}
