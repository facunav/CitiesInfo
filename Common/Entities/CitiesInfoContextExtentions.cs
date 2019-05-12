using System.Collections.Generic;
using System.Linq;

namespace Common.Entities
{
    public static class CitiesInfoContextExtentions
    {
        public static void EnsureSeedDataForContext(this CitiesInfoContext citiesInfoContext)
        {
            if (citiesInfoContext.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                new City()
                {
                    Name = "Buenos Aires",
                    Description = "Capital",
                    PointsOfInterest =  new List<PointsOfInterest>()
                    {
                        new PointsOfInterest()
                        {
                            Name = "La Bombonera",
                            Description = "Boca Juniors"
                        },
                        new PointsOfInterest()
                        {
                            Name = "Obelisco",
                            Description = "Monument"
                        },
                        new PointsOfInterest()
                        {
                            Name = "Zoo",
                            Description = "Animals"
                        }
                    }
                },
                new City()
                {
                    Name = "Mar del Plata",
                    Description = "Coast",
                    PointsOfInterest =  new List<PointsOfInterest>()
                    {
                        new PointsOfInterest()
                        {
                            Name = "Playa Grande",
                            Description = "Beach"
                        },
                        new PointsOfInterest()
                        {
                            Name = "Port",
                            Description = "Ships"
                        },
                        new PointsOfInterest()
                        {
                            Name = "Casino",
                            Description = "Gamble"
                        }
                    }
                },
                new City()
                {
                    Name = "Mendoza",
                    Description = "Wine factories",
                    PointsOfInterest =  new List<PointsOfInterest>()
                    {
                        new PointsOfInterest()
                        {
                            Name = "Winery",
                            Description = "Wine"
                        },
                        new PointsOfInterest()
                        {
                            Name = "Mountains",
                            Description = "Mountains"
                        },
                        new PointsOfInterest()
                        {
                            Name = "Ski",
                            Description = "Ski"
                        }
                    }
                }
            };

            citiesInfoContext.Cities.AddRange(cities);
            citiesInfoContext.SaveChanges();
        }
    }
}
