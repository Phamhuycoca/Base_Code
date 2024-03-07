using Base_code.Application.Common;
using Base_code.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.IServices
{
    public interface IUserService
    {
        PaginatedList<UserDto> Items(int page, int pageSize, string? search);
        bool Create(UserDto user);
        bool Update(UserDto user);
        bool Delete(long id);
        UserDto GetById(long id);
    }
}
