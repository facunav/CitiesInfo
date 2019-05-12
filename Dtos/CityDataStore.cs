using System.Collections.Generic;

namespace Dtos
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();

        public List<City> Cities { get; set; }

        public CityDataStore()
        {
            Cities = new List<City>()
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
            };
        }
    }
}
