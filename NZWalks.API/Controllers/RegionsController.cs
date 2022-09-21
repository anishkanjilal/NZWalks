using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]/NZ-Regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        public RegionsController(IRegionRepository regionRepository)
        {
            this._regionRepository = regionRepository;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions=_regionRepository.GetALL();
            return Ok(regions);
        }
    }
}
