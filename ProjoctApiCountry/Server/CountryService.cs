using AutoMapper;
using FluentNHibernate.Conventions.Inspections;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProjoctApiCountry.Context;
using ProjoctApiCountry.Controllers;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Repostory.IRepostory;
using ProjoctApiCountry.Server;
using System.Net;

namespace ProjoctApiCountry.Server
{
    public class CountryService : ICountryServase
    {
        protected readonly ICountryRepostory repostory;

        protected readonly ILogger<CountryController> logger;

        protected readonly IMapper mapper;

        

        public CountryService(ICountryRepostory repostory, ILogger<CountryController> logger, IMapper mapper)
        {
            this.repostory = repostory ?? throw new ArgumentNullException(nameof(repostory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Country> GetId(int id)
        {
            return await repostory.GetId(id);
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await repostory.GetAll();
        }

        public async Task<CountryDTO> Insert(CountryDTO countryDTO)
        {
            var country = mapper.Map<Country>(countryDTO);
            return (mapper.Map<CountryDTO>(await repostory.Add(country)));
        }

        public async Task<CountryDTO> Update(int id, CountryDTO countryDTO)
        {
            Country coun = mapper.Map<Country>(countryDTO);
            coun.Id = id;
            return (mapper.Map<CountryDTO>(await repostory.Update(id, coun)));
        }

        public async Task<Country> Delete(int id)
        {
            var count = await repostory.GetId(id);
            return (mapper.Map<Country>(await repostory.Delete(id)));
        }
    }
}
