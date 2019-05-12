using System.Linq;
using BusinessLogic;
using Common.Entities;
using Contracts.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stubs;

namespace Tests.Services
{
    //Used to test the service logic
    [TestClass]
    public class CitiesServiceTest
    {
        private readonly Mock<ICityInfoRepository> _cityInfoRepository;
        private readonly CityInfoService _citiesInfoService;

        public CitiesServiceTest()
        {
            _cityInfoRepository = new Mock<ICityInfoRepository>();
            _citiesInfoService = new CityInfoService(_cityInfoRepository.Object);
        }

        [TestMethod]
        public void GetCities()
        {
            var cities = CityStub.GetAll();
            _cityInfoRepository.Setup(c => c.GetCities()).Returns(cities);

            var result = _citiesInfoService.GetCities();

            Assert.IsNotNull(result);
            Assert.AreEqual("Buenos Aires", result.FirstOrDefault().Name);
        }

        [TestMethod]
        public void GetCity_ReturnCity()
        {
            var city = CityStub.GetFirstOne();
            _cityInfoRepository.Setup(c => c.GetCity(It.IsAny<int>())).Returns(city);

            var result = _citiesInfoService.GetCity(1);

            Assert.AreEqual("Buenos Aires", result.Name);
        }

        [TestMethod]
        public void Save()
        {
            var city = CityStub.GetFirstOne();
            _cityInfoRepository.Setup(x => x.AddPointsOfInterestForCity(It.IsAny<int>(), It.IsAny<PointsOfInterest>()));

            _citiesInfoService.AddPointsOfInterestForCity(1, city.PointsOfInterest.FirstOrDefault());

            _cityInfoRepository.Verify(x => x.AddPointsOfInterestForCity(It.IsAny<int>(), It.IsAny<PointsOfInterest>()));
        }
    }
}
