using AutoMapper;
using Base_code.Application.Common;
using Base_code.Application.Dto;
using Base_code.Application.Interfaces.Abstract;
using Base_code.Application.IServices;
using Base_code.Domain.Entities;
using Base_code.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Services
{
    public class UserService : IUserService, IRequest<IResponse>
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        DateTime now = DateTime.Now;
        public UserService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public bool Create(UserDto user)
        {
            var obj = _mapper.Map<User>(user);
            obj.createdAt = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
            return _repo.Create(obj);
        }

        public bool Delete(long id)
        {
            return _repo.Delete(id);
        }

        public UserDto GetById(long id)
        {
            throw new NotImplementedException();
        }

        public PaginatedList<UserDto> Items(int page, int pageSize, string? search)
        {
            var query = _repo.ListData().OrderByDescending(x => x.createdAt);
            var userDtos = query.Select(x => _mapper.Map<UserDto>(x)).ToList();
            return new PaginatedList<UserDto>(userDtos, userDtos.Count, page, pageSize);
        }



        public bool Update(UserDto user)
        {
            var obj = _mapper.Map<User>(user);
            obj.updatedAt = DateTime.Today.AddDays(1).AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second);
            return _repo.Update(obj);
        }
    }
}
