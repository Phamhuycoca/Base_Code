using Base_code.Application.Common;
using Base_code.Application.Dto.Auth;
using Base_code.Application.Dto.UserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base_code.Application.Features.User.Validators
{
    public class UserValidator : AbstractValidator<LoginDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().Matches(Regex.RegexEmail).WithMessage("Email khong hop le.");
        }
    }
}
