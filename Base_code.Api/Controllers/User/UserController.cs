using Base_code.Application.Common;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.IService;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Get(int page = 1, int pageSize = 1, string? search = "")
        {
            try
            {
                var result = _service.Items(page, pageSize, search);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult Create(CreateUserDto dto)
        {
            return Ok(_service.Created(dto));
        }
    }
}
