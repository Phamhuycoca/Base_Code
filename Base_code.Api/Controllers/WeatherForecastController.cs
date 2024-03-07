using Base_code.Application.Common;
using Microsoft.AspNetCore.Mvc;

namespace Base_code.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
          
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get(int id,int limit,string? keyword)
        {
            return Ok("ok");
        }
    }
}