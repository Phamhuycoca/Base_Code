using Base_code.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Base_code.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Authorize(Roles ="Admin")]
        [HttpGet("Admin")]
        public IActionResult Get(int id,int limit,string? keyword)
        {
            return Ok("ok");
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult GetUser(int id, int limit, string? keyword)
        {
            return Ok("GetUser");
        }
    }
}