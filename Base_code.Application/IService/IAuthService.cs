using Base_code.Application.Dto.Auth;
using Base_code.Application.Interfaces.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.IService
{
    public interface IAuthService
    {
        TokenDTO Login(LoginDto dto);
    }
}
