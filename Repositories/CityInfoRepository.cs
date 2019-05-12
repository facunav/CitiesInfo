using System.Collections.Generic;
using System.Linq;
using Common.Entities;
using Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private CitiesInfoContext _citiesInfoContext;

        public CityInfoRepository(CitiesInfoContext citiesInfoContext)
        {
            _citiesInfoContext = citiesInfoContext;
        }

        public bool CityExist(int cityId)
        {
            return _citiesInfoContext.Cities.Any(c => c.CityId == cityId);
        }

        public bool PointsOfInterestExist(int pointsOfInterestId)
        {
            return _citiesInfoContext.PointsOfInterest.Any(c => c.PointOfInterestId == pointsOfInterestId);
        }

        public IEnumerable<Common.Entities.City> GetCities()
        {
            return _citiesInfoContext.Cities.OrderBy(c => c.Name).ToList();
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterest()
        {
            return _citiesInfoContext.PointsOfInterest.OrderBy(c => c.PointOfInterestId).ToList();
        }

        public City GetCity(int cityId)
        {
            return _citiesInfoContext.Cities.Include(c => c.PointsOfInterest)
                    .Single(c => c.CityId == cityId);
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _citiesInfoContext.PointsOfInterest.Where(c => c.CityId == cityId);
        }

        public PointsOfInterest GetPointsOfInterest(int pointsOfInterestId)
        {
            return _citiesInfoContext.PointsOfInterest.Single(c => c.PointOfInterestId == pointsOfInterestId);
        }

        public PointsOfInterest GetPointsOfInterestByName(string name)
        {
            return _citiesInfoContext.PointsOfInterest.Single(c => c.Name.Equals(name));
        }

        public PointsOfInterest GetPointsOfInterestForCity(int cityId, int pointsOfInterestId)
        {
            return _citiesInfoContext.PointsOfInterest.Where(c => c.CityId == cityId && c.PointOfInterestId == pointsOfInterestId).FirstOrDefault();
        }

        public void AddPointsOfInterestForCity(int cityId, PointsOfInterest pointsOfInterest)
        {
            var city = GetCity(cityId);
            city.PointsOfInterest.Add(pointsOfInterest);
        }

        public void AddCity(City city)
        {
            _citiesInfoContext.Add(city);
        }

        public void AddPointsOfInterest(PointsOfInterest pointsOfInterest)
        {
            var city = GetCity(pointsOfInterest.CityId);
            city.PointsOfInterest.Add(pointsOfInterest);
        }

        public void UpdateCity(City city)
        {
            _citiesInfoContext.Update(city);
        }

        public void UpdatePointsOfInterest(PointsOfInterest pointsOfInterest)
        {
            _citiesInfoContext.Update(pointsOfInterest);
        }

        public bool Save()
        {
            return (_citiesInfoContext.SaveChanges() >= 0);
        }

        public void DeletePointOfInterest(PointsOfInterest pointsOfInterest)
        {
            _citiesInfoContext.Remove(pointsOfInterest);
        }

        public void DeleteCity(City city)
        {
            _citiesInfoContext.Remove(city);
        }
    }
}
