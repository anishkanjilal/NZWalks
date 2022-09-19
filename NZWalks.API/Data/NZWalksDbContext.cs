using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDbContextz:DbContext
    {
        public NZWalksDbContextz(DbContextOptions<NZWalksDbContextz> options):base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> walks { get; set; }
        public DbSet<WalkDifficulty> walkDifficulty { get; set; }
    }
}
