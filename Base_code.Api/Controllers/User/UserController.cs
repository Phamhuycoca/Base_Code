using Base_code.Application.Common;
using Base_code.Application.Dto.Auth;
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
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpPost]
        public IActionResult Create(CreateUserDto dto)
        {
            _userService.Create(dto);
            return Ok();
        }
        [HttpPost("Login")]
        public IActionResult CreateD(LoginDto dto)
         {
            LoginDto lg = new LoginDto()
            {
                Email = dto.Email,
                Password = dto.Password
            };
            return Ok(_authService.Login(dto));
        }
    }
}
