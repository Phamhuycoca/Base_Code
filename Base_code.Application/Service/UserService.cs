using AutoMapper;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.IService;
using Base_code.Domain.Entities;
using Base_code.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        public UserService(IUserRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        public void Create(CreateUserDto dto)
        {
            _repo.Create(_mapper.Map<User>(dto));
        }
    }
}
