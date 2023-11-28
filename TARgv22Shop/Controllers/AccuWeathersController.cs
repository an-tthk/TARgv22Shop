using Microsoft.AspNetCore.Mvc;
using Shop.Core.Dto.AccuWeatherDtos;
using Shop.Core.ServiceInterface;
using TARgv22Shop.Models.AccuWeathers;

namespace TARgv22Shop.Controllers
{
    public class AccuWeathersController : Controller
    {
        private readonly IAccuWeatherForecastServices _accuWeatherForecastServices;

        public AccuWeathersController(IAccuWeatherForecastServices accuWeatherForecastServices)
        {
            _accuWeatherForecastServices = accuWeatherForecastServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchCity(SearchCityViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "AccuWeathers", new { city = model.CityName });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult City(string city)
        {
            AccuWeatherResultDto dto = new()
            {
                City = city
            };

            _accuWeatherForecastServices.AccuWeatherResult(dto);
            AccuWeatherViewModel vm = new()
            {
                City = dto.City,
                Key = dto.Key,
                TemperatureMin = dto.TemperatureMin,
                TemperatureMax = dto.TemperatureMax,
                Link = dto.Link,
            };

            return View(vm);
        }
    }
}
