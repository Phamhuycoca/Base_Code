using AutoMapper;
using Base_code.Application.Common;
using Base_code.Application.Dto.Auth;
using Base_code.Application.Dto.UserDto;
using Base_code.Application.Interfaces.Abstract;
using Base_code.Application.Interfaces.Concrete;
using Base_code.Application.IService;
using Base_code.Domain.Exceptions;
using Base_code.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Service
{
    public class AuthService :IAuthService
    {
        private readonly IUserRepo _repo;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        public AuthService(IUserRepo repo,ITokenService tokenService,IMapper mapper) 
        {
            _repo = repo;
            _tokenService = tokenService;
            _mapper = mapper;
        }


        public TokenDTO Login(LoginDto dto)
        {
            var user=_repo.ListData().Where(x=>x.Email == dto.Email && x.Password==dto.Password).SingleOrDefault();
            if (user == null)
            {
                throw new ApiException(404, HttpStatusMessages.UserNotFound);
            }
            var tokendto = _tokenService.CreateToken(_mapper.Map<UserDto>(user));
            return tokendto;
        }
    }
}
