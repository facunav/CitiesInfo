using Microsoft.EntityFrameworkCore;

namespace Common.Entities
{
    //Used to interact with Database
    public class CitiesInfoContext : DbContext
    {
        public CitiesInfoContext(DbContextOptions<CitiesInfoContext> contextOptions) : base(contextOptions)
        {
            Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }

        public DbSet<PointsOfInterest> PointsOfInterest { get; set; }

    }
}
