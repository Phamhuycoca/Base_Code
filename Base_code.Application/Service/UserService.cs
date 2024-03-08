using AutoMapper;
using Base_code.Application.Common;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.Interfaces.Abstract;
using Base_code.Application.Interfaces.Concrete;
using Base_code.Application.IService;
using Base_code.Domain.Entities;
using Base_code.Domain.Repositories;
using log4net;
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
        DateTime now = DateTime.Now;
        private readonly ILog _iLog;
        public UserService(IUserRepo repo, IMapper mapper,ILog iLog)
        {
            _repo = repo;
            _mapper = mapper;
            _iLog = iLog;

        }

        public DataResponse<CreateUserDto> Created(CreateUserDto user)
        {
            try
            {
                var obj = _mapper.Map<User>(user);
                obj.Password = "12345678a";
                obj.createdAt = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
                _repo.Create(obj);
                var createdUserDto = _mapper.Map<CreateUserDto>(obj);
                return new DataResponse<CreateUserDto>(createdUserDto, 200, HttpStatusMessages.AddedSuccesfully);
            }catch (Exception ex)
            {
                _iLog.Error(ex.Message);
                return new DataResponse<CreateUserDto>(null, 500, "Ok");
            }
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public UserDto GetById(long id)
        {
            throw new NotImplementedException();
        }

        public DataResponse<List<UserDto>> Items(int page, int pageSize, string? search)
        {
            var query = _mapper.Map<List<UserDto>>(_repo.ListData());

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(x => x.FullName.Contains(search)).ToList();
            }

            var paginatedResult = PaginatedList<UserDto>.ToPageList(query, page, pageSize);

            return new DataResponse<List<UserDto>>(paginatedResult, query.Count(), 200);
        }

        public void Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
