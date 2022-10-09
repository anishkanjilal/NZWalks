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

        public async Task<Region> GetAsync(Guid Id)
        {
            var region =await  nZWalksDbContextz.Regions.FirstOrDefaultAsync(r => r.Id == Id);
            return region;
        }
        
        public async Task<Region> AddAsync(Region region)
        {
            region.Id= Guid.NewGuid();
            await nZWalksDbContextz.AddAsync(region);
            await nZWalksDbContextz.SaveChangesAsync();
            return region;
        }


        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nZWalksDbContextz.Regions.FirstOrDefaultAsync(x=>x.Id == id);
            if (region == null)
                return null;

            nZWalksDbContextz.Regions.Remove(region);
            await nZWalksDbContextz.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var ExistingRegion = await nZWalksDbContextz.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
                return null;

            ExistingRegion.Code = region.Code;
            ExistingRegion.Name = region.Name;
            ExistingRegion.Area = region.Area;
            ExistingRegion.Lat = region.Lat;
            ExistingRegion.Long=region.Long;
            ExistingRegion.Population=region.Population;

            await nZWalksDbContextz.SaveChangesAsync();

            return ExistingRegion;
        }
    }
}
