using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjoctApiCountry.Context;
using ProjoctApiCountry.DTO;
using ProjoctApiCountry.Model;
using ProjoctApiCountry.Server;

namespace ProjoctApiCountry.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionServer regions;

        public RegionController(IRegionServer regions)
        {
            this.regions = regions ?? throw new ArgumentNullException(nameof(regions));
        }

        [HttpPost]

        public async Task<IActionResult> Insert([FromBody] RegionDTO regionDTO)
        {

            return Ok(await regions.Inter(regionDTO));
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await regions.GetAll());
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RegionDTO regionDTO)
        {
            return Ok(await regions.Update(id, regionDTO)); 
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult>Delete(int id)
        {
            return Ok(await regions.Delete(id));
        }
        
        [HttpGet("{id}")]

        public async Task<IActionResult> GetID(int id)
        {
            return Ok(await regions.Get(id));
        }
    }
}
