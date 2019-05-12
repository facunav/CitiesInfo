using System;
using System.Collections.Generic;
using AutoMapper;
using CitiesInfo.ViewModels;
using Contracts.Services;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CitiesInfo.Controllers
{
    [Route("api/cities")]
    [ApiController]
    public class CitiesController : Controller
    {
        private ICityInfoService _cityInfoService;
        private ILogger<PointsOfInterestController> _logger;
        private IMapper _mapper;

        public CitiesController(ILogger<PointsOfInterestController> logger, ICityInfoService cityInfoService, IMapper mapper)
        {
            _logger = logger;
            _cityInfoService = cityInfoService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return RedirectToAction("GetCities");
        }

        [HttpGet()]
        public IActionResult GetCities()
        {
            try
            {
                var citiesEntity = _cityInfoService.GetCities();

                var cities = _mapper.Map<IEnumerable<City>>(citiesEntity);

                return View(cities);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting PointsOfInterest", ex);

                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("GetCity/{cityId}")]
        public IActionResult GetCity(int cityId)
        {
            try
            {
                var citiesEntity = _cityInfoService.GetCity(cityId);

                var city = _mapper.Map<City>(citiesEntity);

                return View(city);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting PointsOfInterest", ex);

                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{cityId}")]
        public IActionResult EditCity(int cityId)
        {
            try
            {
                var cityDb = _cityInfoService.GetCity(cityId);

                if (cityDb == null)
                {
                    _logger.LogInformation($"The city with Id {cityId} wasn't found.");
                    return NotFound();
                }

                var city = _mapper.Map<City>(cityDb);

                return View(city);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting City with cityId {cityId}", ex);

                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpPost("{cityid}")]
        public IActionResult EditCity([FromForm]CityVm city)
        {
            if (city == null)
            {
                _logger.LogInformation($"The city can not be null.");
                return BadRequest();
            }

            if (!_cityInfoService.CityExist(city.CityId))
            {
                _logger.LogInformation($"The city {city.Name} does not exist.");
                return NotFound();
            }

            var cityToUpdate = _mapper.Map<Common.Entities.City>(city);

            _cityInfoService.UpdateCity(cityToUpdate);

            if (!_cityInfoService.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            };

            return RedirectToAction("GetCities");
        }

        [HttpGet("delete/{cityId}")]
        public IActionResult DeleteCity(int cityId)
        {
            var cityDb = _cityInfoService.GetCity(cityId);

            if (cityDb == null)
            {
                _logger.LogInformation($"The city with Id {cityId} does not exist.");
                return NotFound();
            }

            var city = _mapper.Map<City>(cityDb);

            return View(city);
        }

        [HttpPost("delete/{cityid}")]
        public IActionResult DeleteCity([FromForm]CityVm city)
        {
            if (!_cityInfoService.CityExist(city.CityId))
            {
                _logger.LogInformation($"The city with Id {city.CityId} does not exist.");
                return NotFound();
            }

            _cityInfoService.DeletePointOfInterestFromCity(city.CityId);

            var cityEntity = _mapper.Map<Common.Entities.City>(city);

            _cityInfoService.DeleteCity(cityEntity);

            if (!_cityInfoService.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            };

            return RedirectToAction("GetCities");
        }

        [HttpGet("create")]
        public IActionResult CreateCity()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateCity([FromForm] CityVm cityVm)
        {
            if (cityVm == null)
            {
                _logger.LogInformation($"The city can not be null.");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalCity = _mapper.Map<Common.Entities.City>(cityVm);

            _cityInfoService.AddCity(finalCity);

            if (!_cityInfoService.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            };

            return RedirectToAction("GetCities");
        }
    }
}
