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
    [Route("api/pointsofinterest")]
    public class PointsOfInterestController : Controller
    {
        private ILogger<PointsOfInterestController> _logger;
        private ICityInfoService _cityInfoService;
        private IMapper _mapper;

        public PointsOfInterestController(ILogger<PointsOfInterestController> logger, ICityInfoService cityInfoService, IMapper mapper)
        {
            _logger = logger;
            _cityInfoService = cityInfoService;
            _mapper = mapper;
        }

        [HttpGet()]
        public IActionResult GetPointOfInterest()
        {
            try
            {
                var pointsOfInterest = _cityInfoService.GetPointsOfInterest();

                var pointsOfInterestResult = _mapper.Map<IEnumerable<PointsOfInterest>>(pointsOfInterest);

                return View(pointsOfInterestResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting PointsOfInterest", ex);

                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{cityid}/pointsofinterest")]
        public IActionResult GetPointOfInterest(int cityid)
        {
            try
            {
                if (!_cityInfoService.CityExist(cityid))
                {
                    _logger.LogInformation($"The city with Id {cityid} wasn't found.");
                    return NotFound();
                }

                var pointsOfInterest = _cityInfoService.GetPointsOfInterestForCity(cityid);

                var pointsOfInterestResult = _mapper.Map<IEnumerable<PointsOfInterest>>(pointsOfInterest);

                return View(pointsOfInterestResult);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting PointsOfInterest with cityId {cityid}", ex);

                return StatusCode(500, "A problem happened while handling your request");
            }
        }

        [HttpGet("{pointsofinterestid}")]
        public IActionResult EditPointOfInterest(int pointsofinterestid)
        {
            var pointsofinterestDb = _cityInfoService.GetPointsOfInterest(pointsofinterestid);

            if (pointsofinterestDb == null)
            {
                _logger.LogInformation($"The points of interest with Id {pointsofinterestid} does not exist.");
                return NotFound();
            }

            var pointsofinterest = _mapper.Map<PointsOfInterest>(pointsofinterestDb);

            return View(pointsofinterest);
        }

        [HttpPost("{pointsofinterestid}")]
        public IActionResult EditPointsOfInterest([FromForm] PointsOfInterestVm pointsOfInterest)
        {
            if (pointsOfInterest == null)
            {
                _logger.LogInformation($"The points of interest can not be null.");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pointofinterestDb = _cityInfoService.GetPointsOfInterest(pointsOfInterest.PointOfInterestId);

            if (!_cityInfoService.PointOfInterestExist(pointofinterestDb.PointOfInterestId))
            {
                _logger.LogInformation($"The points of interest can not be null.");
                return NotFound();
            }

            var pointOfInterestToUpdate = _mapper.Map<Common.Entities.PointsOfInterest>(pointofinterestDb);

            _cityInfoService.UpdatePointsOfInterest(pointOfInterestToUpdate);

            if (!_cityInfoService.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            };

            return RedirectToAction($"{pointOfInterestToUpdate.CityId.ToString()}/pointsofinterest", "api/pointsofinterest");
        }

        [HttpGet("create")]
        public IActionResult CreatePointOfInterest()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreatePointsOfInterest([FromForm] PointsOfInterestVm pointsOfInterest)
        {
            if (pointsOfInterest == null)
            {
                _logger.LogInformation($"The points of interest can not be null.");
                return BadRequest();
            }

            if (!_cityInfoService.CityExist(pointsOfInterest.CityId))
            {
                _logger.LogInformation($"The city with Id {pointsOfInterest.CityId} does not exist.");
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var finalPointOfInterest = _mapper.Map<Common.Entities.PointsOfInterest>(pointsOfInterest);

            _cityInfoService.AddPointsOfInterest(finalPointOfInterest);

            if (!_cityInfoService.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            };

            return RedirectToAction($"{finalPointOfInterest.CityId.ToString()}/pointsofinterest", "api/pointsofinterest");
        }


        [HttpGet("delete/{pointsofinterestid}")]
        public IActionResult DeletePointsOfInterest(int pointsofinterestid)
        {
            var pointsOfInterestDb = _cityInfoService.GetPointsOfInterest(pointsofinterestid);

            if (pointsOfInterestDb == null)
            {
                _logger.LogInformation($"The points of interest with id {pointsofinterestid} does not exist.");
                return NotFound();
            }

            var pointsOfInterest = _mapper.Map<PointsOfInterest>(pointsOfInterestDb);

            return View(pointsOfInterest);
        }

        [HttpPost("delete/{pointsofinterestid}")]
        public IActionResult DeletePointsOfInterest([FromForm]PointsOfInterestVm pointOfInterest)
        {
            if (!_cityInfoService.PointOfInterestExist(pointOfInterest.PointOfInterestId))
            {
                _logger.LogInformation($"The points of interest with id {pointOfInterest.PointOfInterestId} does not exist.");
                return NotFound();
            }

            var pointOfInterestEntity = _mapper.Map<Common.Entities.PointsOfInterest>(pointOfInterest);

            _cityInfoService.DeletePointOfInterest(pointOfInterestEntity);

            if (!_cityInfoService.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            };

            return RedirectToAction($"{pointOfInterestEntity.CityId.ToString()}/pointsofinterest", "api/pointsofinterest");
        }
    }
}
