using Application.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class EnrollmentDTOValidator : AbstractValidator<CreateEnrollmentDTO>
    {
        public EnrollmentDTOValidator() 
        {
            RuleFor(x => x.CourseId).GreaterThan(0).WithMessage("Course must be selected");
            RuleFor(x => x.TraineeId).GreaterThan(0).WithMessage("Trainee must be selected");
        }
    }
}
