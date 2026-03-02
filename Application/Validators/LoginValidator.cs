using Application.DTOS.UsersDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class LoginValidator : AbstractValidator<LoginDTO>
    {
        public LoginValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("A valid email must be added");
        }
    }
}
