using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;
using System.Runtime.InteropServices;
using System.Xml.Linq;

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
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region_details = await _regionRepository.GetAsync(id);
            if(region_details == null)
            {
                return NotFound();
            }
            var result= mapper.Map<Models.DTO.RegionDTO>(region_details);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddregionAsync(AddOrUpdateRegionRequest addRegionRequest)
        {
            var region = new Region()
            {
                Code = addRegionRequest.Code,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Name = addRegionRequest.Name,
                Population = addRegionRequest.Population
            };
            var add_region = await _regionRepository.AddAsync(region);

            var regiondto = new RegionDTO()
            {
                Id = add_region.Id,
                Area = add_region.Area,
                Lat = add_region.Lat,
                Long = add_region.Long,
                Name = add_region.Name,
                Population = add_region.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync),new {id= regiondto.Id}, regiondto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionasync(Guid id)
        {

            var region = await _regionRepository.DeleteAsync(id);

            if (region == null)
                return NotFound();

            var regiondto = new RegionDTO()
            {
                Id = region.Id,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };
            return Ok(regiondto);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]Guid id,[FromBody] AddOrUpdateRegionRequest updated_region)
        {

            var new_updated_region = new Region()
            {
                Code = updated_region.Code,
                Name = updated_region.Name,
                Area =updated_region.Area,
                Lat = updated_region.Lat,
                Long =updated_region.Long,
                Population = updated_region.Population

            };
            var ExisitingRegion = await _regionRepository.UpdateAsync(id, new_updated_region);
            if (ExisitingRegion == null)
                return NotFound();

            var region_dto = new RegionDTO()
            {
                Id= ExisitingRegion.Id,
                Name = ExisitingRegion.Name,
                Area = ExisitingRegion.Area,
                Lat = ExisitingRegion.Lat,
                Long = ExisitingRegion.Long,
                Population = ExisitingRegion.Population,

            };
            return Ok(region_dto);

        }
    }
}
