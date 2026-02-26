using Application.DTOS.GradesDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class AddTraineeGradeValidatorDTO : AbstractValidator<AddTraineeGradeDTO>
    {
        public AddTraineeGradeValidatorDTO() 
        {
            RuleFor(x => x.Grade).GreaterThan(0).WithMessage("please add grade");
            RuleFor(x => x.EnrollmentId).GreaterThan(0).WithMessage("please add enrollment");
        }
    }
}
