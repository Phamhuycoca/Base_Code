using Base_code.Application.Dto.UserDto;
using Base_code.Application.Interfaces.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.IService
{
    public interface IUserService
    {
        DataResponse<List<UserDto>> Items(int page, int pageSize, string? search);
        DataResponse<CreateUserDto> Created(CreateUserDto user);
        void Update(UserDto user);
        void Delete(long id);
        UserDto GetById(long id);
    }
}
