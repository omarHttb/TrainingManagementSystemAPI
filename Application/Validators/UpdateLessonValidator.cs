using Application.DTOS.LessonsDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdateLessonValidator : AbstractValidator<UpdateLessonDTO>
    {
        public UpdateLessonValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Lesson ID must be greater than 0.");
            RuleFor(x => x.LessonName)
                .NotEmpty().WithMessage("Lesson name is required.");
            RuleFor(x => x.LessonDescription)
                .NotEmpty().WithMessage("Lesson description is required.");
        }
    }
}
