using Base_code.Application.Dto.Auth;
using Base_code.Application.Dto.UserDto;
using Base_code.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.IService
{
    public interface ITokenService
    {
        TokenDTO CreateToken(UserDto user);

    }
}
