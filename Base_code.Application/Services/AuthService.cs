using AutoMapper;
using Base_code.Application.Dto.AuthDto;
using Base_code.Application.Interfaces.Concrete;
using Base_code.Application.IServices;
using Base_code.Domain.Exceptions;
using Base_code.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        public AuthService(IUserRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public DataResponse<LoginDto> Login(LoginDto dto)
        {
            var user = _repo.ListData().Where(x=>x.Email==dto.Email);
            if (user == null)
            {
                throw new ApiException(404, "Not Fount");
            }
            return new DataResponse<LoginDto>(dto,1,200);
        }

        public DataResponse<RegisterDto> Register(RegisterDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
