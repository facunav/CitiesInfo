using System.Collections.Generic;
using System.Linq;
using Common.Entities;

namespace Stubs
{
    //Used to mock fake data for testing 
    public static class CityStub
    {
        static IQueryable<City> DataSource => new List<City>
        {
            new City()
            {
                CityId = 1,
                Name = "Buenos Aires",
                Description = "Capital",
                PointsOfInterest =  new List<PointsOfInterest>()
                {
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 1,
                        Name = "La Bombonera",
                        Description = "Boca Juniors"
                    },
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 2,
                        Name = "Obelisco",
                        Description = "Monument"
                    },
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 3,
                        Name = "Zoo",
                        Description = "Animals"
                    }
                }
            },
            new City()
            {
                CityId = 2,
                Name = "Mar del Plata",
                Description = "Coast",
                PointsOfInterest =  new List<PointsOfInterest>()
                {
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 1,
                        Name = "Playa Grande",
                        Description = "Beach"
                    },
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 2,
                        Name = "Port",
                        Description = "Ships"
                    },
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 3,
                        Name = "Casino",
                        Description = "Gamble"
                    }
                }
            },
            new City()
            {
                CityId = 3,
                Name = "Mendoza",
                Description = "Wine factories",
                PointsOfInterest =  new List<PointsOfInterest>()
                {
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 1,
                        Name = "Winery",
                        Description = "Wine"
                    },
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 2,
                        Name = "Mountains",
                        Description = "Mountains"
                    },
                    new PointsOfInterest()
                    {
                        PointOfInterestId = 3,
                        Name = "Ski",
                        Description = "Ski"
                    }
                }

            }

        }.AsQueryable();

        public static IEnumerable<City> GetAll()
        {
            return DataSource;
        }

        public static City GetFirstOne()
        {
            return DataSource.First();
        }
    }
}