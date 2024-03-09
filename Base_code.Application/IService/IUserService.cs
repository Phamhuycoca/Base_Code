using Base_code.Application.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.IService
{
    public interface IUserService
    {
        void Create(CreateUserDto dto);
    }
}
