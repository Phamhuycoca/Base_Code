using Base_code.Application.Common;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.Interfaces.Abstract;
using Base_code.Application.Interfaces.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.IServices
{
    public interface IUserService
    {
        DataResponse<List<UserDto>> Items(int page, int pageSize, string? search);
        DataResponse<UserDto> Created(UserDto user);
        void Update(UserDto user);
        void Delete(long id);
        UserDto GetById(long id);
    }
}
