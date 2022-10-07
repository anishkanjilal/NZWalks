using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContextz nZWalksDbContextz;
        public RegionRepository(NZWalksDbContextz nZWalksDbContextz)
        {
            this.nZWalksDbContextz = nZWalksDbContextz;
        }
        public async Task<IEnumerable<Region>> GetALLAsync()
        {
            return await nZWalksDbContextz.Regions.ToListAsync();
        }
    }
}
