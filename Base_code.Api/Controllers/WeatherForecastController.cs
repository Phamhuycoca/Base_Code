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
        private IEnumerable<User> userList = new List<User>();
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            userList = new List<User>
            {
                new User { Email = "user1@example.com", Password = "password1" },
                new User { Email = "user2@example.com", Password = "password2" },
                new User { Email = "user2@example.com", Password = "password2" },
                new User { Email = "user2@example.com", Password = "password2" },
                new User { Email = "user2@example.com", Password = "password2" },
                new User { Email = "user2@example.com", Password = "password2" },
                new User { Email = "user2@example.com", Password = "password2" },
                new User { Email = "user2@example.com", Password = "password2" },
            };
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get(int id,int limit,string? keyword)
        {
            var pageList = PageList<User>.listData(userList, id,limit);
            return Ok(pageList);
        }
        [HttpPost]
        public IActionResult Create(User model)
        {
            try
            {
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}