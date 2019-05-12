using System.Collections.Generic;
using AutoMapper;
using CitiesInfo.Controllers;
using Contracts.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Stubs;

namespace Tests.Controllers
{
    //Used to test the controller logic
    [TestClass]
    public class CitiesControllerTest
    {
        private readonly Mock<ICityInfoService> _cityInfoService;
        private readonly Mock<ILogger<PointsOfInterestController>> _logger;
        private readonly Mock<IMapper> _mapper;
        private readonly CitiesController _citiesController;

        public CitiesControllerTest()
        {
            _mapper = new Mock<IMapper>();
            _cityInfoService = new Mock<ICityInfoService>();
            _logger = new Mock<ILogger<PointsOfInterestController>>();
            _citiesController = new CitiesController(_logger.Object, _cityInfoService.Object, _mapper.Object);
        }

        [TestMethod]
        public void GetCities()
        {
            var citiesDto = CityStubDto.GetAll();
            var cities = CityStub.GetAll();
            _cityInfoService.Setup(c => c.GetCities()).Returns(cities);

            _mapper.Setup(x => x.Map<IEnumerable<Dtos.City>>(cities)).Returns(citiesDto);

            var result = _citiesController.GetCities() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(citiesDto, (IEnumerable<Dtos.City>)result.ViewData.Model);
        }

        [TestMethod]
        public void GetCity_ReturnCity()
        {
            var cityDto = CityStubDto.GetFirstOne();
            var city = CityStub.GetFirstOne();
            _cityInfoService.Setup(c => c.GetCity(It.IsAny<int>())).Returns(city);

            _mapper.Setup(x => x.Map<Dtos.City>(city)).Returns(cityDto);

            var result = _citiesController.GetCity(1) as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual(cityDto, (Dtos.City)result.ViewData.Model);
        }

        [TestMethod]
        public void GetCity_ReturnNotFound()
        {
            var cityDto = CityStubDto.GetFirstOne();
            Common.Entities.City city = null;
            _cityInfoService.Setup(c => c.GetCity(It.IsAny<int>())).Returns(city);

            //_mapper.Setup(x => x.Map<Common.Entities.City, Dtos.City>(city)).Returns(cityDto);

            var result = _citiesController.GetCity(5) as OkObjectResult;

            Assert.IsNull(result);
        }
    }
}
