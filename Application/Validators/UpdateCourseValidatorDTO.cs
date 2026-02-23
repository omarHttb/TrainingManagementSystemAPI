using Application.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdateCourseValidatorDTO : AbstractValidator<UpdateCourseDTO>
    {
        public UpdateCourseValidatorDTO() 
        {
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
            RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Capacity must be greater than 0");
            RuleFor(x => x.Title).NotEmpty().NotNull().WithMessage("Title must be added");
            RuleFor(x => x.Description).NotEmpty().NotNull().WithMessage("Description must be added");

        }
    }
}
