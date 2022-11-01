using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjoctApiCountry.Context;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Server;

namespace ProjoctApiCountry.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class CountryController : ControllerBase
    {
        protected readonly ICountryServase servase;



        public CountryController(ICountryServase servase)
        {
            this.servase = servase ?? throw new ArgumentNullException(nameof(servase));
        }
        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] CountryDTO countryDTO)
        {
            return Ok(await servase.Insert(countryDTO));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await servase.GetAll());
        }

        [HttpPut("{id}")]

        public async Task<IActionResult>Update(int id, [FromBody] CountryDTO country)
        {
            return Ok(await servase.Update(id, country));
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await servase.Delete(id));
        }
        [HttpGet("{id}")]
         public async Task<IActionResult> GetId(int id)
        {
            return Ok(await servase.GetId(id));
        }
    }
}
