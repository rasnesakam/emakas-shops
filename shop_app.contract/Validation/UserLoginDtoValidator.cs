using FluentValidation;
using shop_app.contract.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop_app.contract.Validation
{
    public class UserLoginDtoValidator: AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
           /* 
            RuleFor(dto => dto.UserName).NotEmpty();
            RuleFor(dto => dto.Password).NotEmpty();
            RuleFor(dto => dto.UserName).MaximumLength(30);
            RuleFor(dto => dto.Password).MaximumLength(30);
            */
        }
    }
}
