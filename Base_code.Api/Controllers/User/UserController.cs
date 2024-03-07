using Base_code.Application.Dto;
using Base_code.Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Base_code.Api.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }
        [HttpGet]
        public IActionResult Items(int page=1,int pageSize=10,string? search="")
        {
            return Ok(_service.Items(page,pageSize,search));
        }
        [HttpPost]
        public IActionResult Create(UserDto dto)
        {
            return Ok(_service.Create(dto));
        }
    }
}
