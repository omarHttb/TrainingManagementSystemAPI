using Application.DTOS;
using Application.DTOS.TrainersDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateTrainerValidator : AbstractValidator<CreateTrainerDTO>
    {
        public CreateTrainerValidator() 
        {
            RuleFor(x => x.TeachingSubject)
                .NotEmpty()
                .NotNull()
                .WithMessage("Teaching subject must be added");

            RuleFor(x => x.ExperienceYears)
                .GreaterThan((short)0)
                .WithMessage("Experience years must be greater than 0");

            RuleFor(x=> x.Headline)
                .NotEmpty()
                .NotNull()
                .WithMessage("Headline must be added");
        }
    }
}
