using AutoMapper;
using Base_code.Application.Common;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.Interfaces.Abstract;
using Base_code.Application.Interfaces.Concrete;
using Base_code.Application.IService;
using Base_code.Domain.Entities;
using Base_code.Domain.Exceptions;
using Base_code.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Service
{
    public class UserService : IUserService, IRequest<IResponse>
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(IUserRepo repo, IMapper mapper, ILogger<UserService> logger)
        {
            _mapper = mapper;
            _repo = repo;
            _logger = logger;
        }
  

        public DataResponse<CreateUserDto> Create(CreateUserDto user)
        {
                var checkEmail = _repo.ListData().Any(x => x.Email == user.Email);

                if (checkEmail)
                {
                       _logger.LogWarning("Không thể tạo mới người dùng.");
                       throw new ApiException(HttpStatusCode.BAD_REQUEST, "Email đã tồn tại");
                }
                var data = _mapper.Map<User>(user);
                _repo.Create(data);
                return new DataResponse<CreateUserDto>(user, HttpStatusCode.OK, HttpStatusMessages.AddedSuccesfully);
        }

        public DataResponse<List<UserDto>> Items(int page, int pageSize, string? search)
        {
            try
            {
                var query = _mapper.Map<List<UserDto>>(_repo.ListData());
                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(x => x.FullName.Contains(search)).ToList();
                }
                var paginatedResult = PaginatedList<UserDto>.ToPageList(query, page, pageSize);
                return new DataResponse<List<UserDto>>(paginatedResult, paginatedResult.Count(), 200,"success");
            }catch (Exception ex)
            {
                _logger.LogError(ex, "Không thể lấy danh sách người dùng.");
                throw new ApiException(HttpStatusCode.BAD_REQUEST, "Không thể lấy danh sách người dùng.");
            }
        }

       
    }
}
