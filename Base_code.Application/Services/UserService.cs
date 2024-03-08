using AutoMapper;
using Base_code.Application.Common;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.Interfaces.Abstract;
using Base_code.Application.Interfaces.Concrete;
using Base_code.Application.IServices;
using Base_code.Domain.Entities;
using Base_code.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Services
{
    public class UserService : IUserService,IRequest<IResponse>
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        DateTime now = DateTime.Now;
        public UserService(IUserRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            
        }

        public DataResponse<UserDto> Created(UserDto user)
        {
            var obj = _mapper.Map<User>(user);
            obj.Password = "12345678a";
            obj.createdAt = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
            _repo.Create(obj);
            var createdUserDto = _mapper.Map<UserDto>(obj);
            return new DataResponse<UserDto>(createdUserDto, 200, HttpStatusMessages.AddedSuccesfully);
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

