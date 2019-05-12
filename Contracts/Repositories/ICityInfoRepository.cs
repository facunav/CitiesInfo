using System.Collections.Generic;
using Common.Entities;

namespace Contracts.Repositories
{
    public interface ICityInfoRepository
    {
        bool CityExist(int cityId);

        bool PointsOfInterestExist(int pointsOfInterestId);

        IEnumerable<City> GetCities();

        IEnumerable<PointsOfInterest> GetPointsOfInterest();

        City GetCity(int cityId);

        PointsOfInterest GetPointsOfInterest(int pointsOfInterestId);

        PointsOfInterest GetPointsOfInterestByName(string name);

        IEnumerable<PointsOfInterest> GetPointsOfInterestForCity(int cityId);

        PointsOfInterest GetPointsOfInterestForCity(int cityId, int pointsOfInterestId);

        bool Save();

        void UpdateCity(City city);

        void UpdatePointsOfInterest(PointsOfInterest pointsOfInterest);

        void AddPointsOfInterestForCity(int cityId, PointsOfInterest pointsOfInterest);

        void AddPointsOfInterest(PointsOfInterest pointsOfInterest);

        void DeletePointOfInterest(PointsOfInterest pointsOfInterest);

        void DeleteCity(City city);

        void AddCity(City city);
    }
}
