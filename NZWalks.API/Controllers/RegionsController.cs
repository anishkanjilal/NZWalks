using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]/NZ-Regions")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper mapper;
        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this._regionRepository = regionRepository;
            this.mapper = mapper;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionRepository.GetALLAsync();
            //return dto regions
            //var dto_list_of_region = new List<RegionDTO>();
            //regions.ToList().ForEach(x =>
            //{
            //    var regiondto = new RegionDTO()
            //    {
            //        Id = x.Id,
            //        Name = x.Name,
            //        Code = x.Code,
            //        Area = x.Area,
            //        Lat = x.Lat,
            //        Long = x.Long,
            //        Population = x.Population
            //    };
            //    dto_list_of_region.Add(regiondto);
            //});
            var dto_list_of_region = mapper.Map<List<Models.DTO.RegionDTO>>(regions);
            return Ok(dto_list_of_region);
        }
    }
}
