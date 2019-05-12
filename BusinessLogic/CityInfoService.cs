using System.Collections.Generic;
using Common.Entities;
using Contracts.Repositories;
using Contracts.Services;

namespace BusinessLogic
{
    //Used to add business logic
    public class CityInfoService : ICityInfoService
    {
        private ICityInfoRepository _cityInfoRepository;

        public CityInfoService(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }

        public bool CityExist(int cityId)
        {
            return _cityInfoRepository.CityExist(cityId);
        }

        public bool PointOfInterestExist(int pointOfInterestId)
        {
            return _cityInfoRepository.PointsOfInterestExist(pointOfInterestId);
        }

        public IEnumerable<City> GetCities()
        {
            return _cityInfoRepository.GetCities();
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterest()
        {
            return _cityInfoRepository.GetPointsOfInterest();
        }

        public PointsOfInterest GetPointsOfInterestByName(string name)
        {
            return _cityInfoRepository.GetPointsOfInterestByName(name);
        }

        public City GetCity(int cityId)
        {
            return _cityInfoRepository.GetCity(cityId);
        }

        public PointsOfInterest GetPointsOfInterest(int pointsOfInterestId)
        {
            return _cityInfoRepository.GetPointsOfInterest(pointsOfInterestId);
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _cityInfoRepository.GetPointsOfInterestForCity(cityId);
        }

        public PointsOfInterest GetPointsOfInterestForCity(int cityId, int pointsOfInterestId)
        {
            return _cityInfoRepository.GetPointsOfInterestForCity(cityId, pointsOfInterestId);
        }

        public void AddPointsOfInterestForCity(int cityId, PointsOfInterest pointsOfInterest)
        {
            _cityInfoRepository.AddPointsOfInterestForCity(cityId, pointsOfInterest);
        }

        public void AddPointsOfInterest(PointsOfInterest pointsOfInterest)
        {
            _cityInfoRepository.AddPointsOfInterest(pointsOfInterest);
        }

        public bool Save()
        {
            return _cityInfoRepository.Save();
        }

        public void UpdateCity(City city)
        {
            _cityInfoRepository.UpdateCity(city);
        }

        public void UpdatePointsOfInterest(PointsOfInterest pointsOfInterest)
        {
            _cityInfoRepository.UpdatePointsOfInterest(pointsOfInterest);
        }

        public void DeletePointOfInterest(PointsOfInterest pointsOfInterest)
        {
            _cityInfoRepository.DeletePointOfInterest(pointsOfInterest);
        }

        public void DeletePointOfInterestFromCity(int cityId)
        {
            var pointsOfInterests = GetPointsOfInterestForCity(cityId);

            foreach (var point in pointsOfInterests)
            {
                _cityInfoRepository.DeletePointOfInterest(point);
            }
        }

        public void DeleteCity(City city)
        {
            _cityInfoRepository.DeleteCity(city);
        }

        public void AddCity(City city)
        {
            _cityInfoRepository.AddCity(city);
        }
    }
}
