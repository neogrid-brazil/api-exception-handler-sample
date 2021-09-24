using ExceptionHandlerSample.Business;
using ExceptionHandlerSample.Domain;
using ExceptionHandlerSample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandlerSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastBusiness _business;

        public WeatherForecastController(IWeatherForecastBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public WeatherForecast Get(string location)
        {
            return _business.DoForecast(location);
        }

        [HttpPost]
        public IActionResult Post(WeatherViewModel viewModel)
        {
            return Ok();
        }
    }
}
