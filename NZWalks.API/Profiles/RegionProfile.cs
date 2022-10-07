using AutoMapper;

namespace NZWalks.API.Profiles
{
    public class RegionProfile:Profile
    {
        public RegionProfile()
        {
            CreateMap<Models.Domain.Region,Models.DTO.RegionDTO>()
                //ForMember(dest =>dest.Id,source => source.MapFrom(src=>src.Id))
                ;
        }
    }
}
