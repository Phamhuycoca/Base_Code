using Base_code.Application.Dto.AuthDto;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.Interfaces.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.IServices
{
    public interface IAuthService
    {
        DataResponse<LoginDto> Login(LoginDto dto);
        DataResponse<RegisterDto> Register(RegisterDto dto);

    }
}
