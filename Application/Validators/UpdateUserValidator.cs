using Application.DTOS.UsersDTOS;
using Application.RepositoryInterfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDTO>
    {
        IUserRepository _userRepository;
        public UpdateUserValidator(IUserRepository userRepository) 
        {
            _userRepository = userRepository;
            RuleFor(x => x.FirstName).NotEmpty().NotNull().WithMessage("First name must be added");
            RuleFor(x => x.LastName).NotEmpty().NotNull().WithMessage("Last name must be added");
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress().WithMessage("A valid email must be added");
            RuleFor(x => x.Email).MustAsync(async (dto, email, cancellation) =>
            {
                return await _userRepository.DoesEmailExist(email, dto.Id);
            }).WithMessage("Email already exists");
        }
    }
}
