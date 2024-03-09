using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Base_code.Api.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }
        protected IActionResult ApiResponse(object data, string message = null)
        {
            var response = new
            {
                Success = true,
                Data = data,
                Message = message
            };

            return Ok(response);
        }

        protected IActionResult ApiError(string message, int statusCode = 500)
        {
            var response = new
            {
                Success = false,
                Message = message
            };

            return StatusCode(statusCode, response);
        }
        protected IActionResult ApiResponseList(List<object> data,int count,string message=null)
        {
            var response = new
            {
                totalItems=count,
                Success = true,
                Data = data,
                Message = message
            };

            return Ok(response);
        }
    }
}
