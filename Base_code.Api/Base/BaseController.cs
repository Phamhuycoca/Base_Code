using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace Base_code.Api.Base
{
    public class BaseController:ControllerBase
    {
        protected IActionResult CreateResponse<T>(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ObjectResult(new
            {
                Success = true,
                Data = data
            })
            {
                StatusCode = (int)statusCode
            };
        }

        protected IActionResult CreateErrorResponse(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ObjectResult(new
            {
                Success = false,
                Error = message
            })
            {
                StatusCode = (int)statusCode
            };
        }
        protected IActionResult CreateListResponse<T>(List<T> dataList, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ObjectResult(new
            {
                Success = true,
                DataList = dataList
            })
            {
                StatusCode = (int)statusCode
            };
        }
    }
}
