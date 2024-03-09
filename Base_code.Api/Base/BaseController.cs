using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Base_code.Api.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected long? UserId
        {
            get
            {
                var userIdClaim = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userIdClaim != null && long.TryParse(userIdClaim, out var userId))
                {
                    return userId;
                }

                return null;
            }
        }
    }
}
