using Application.DTOS.LessonsDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateLessonValidator : AbstractValidator<CreateLessonDTO> 
    {
        public CreateLessonValidator()
        {
            RuleFor(x => x.LessonName)
                .NotEmpty().WithMessage("Lesson name is required.");
                
            RuleFor(x => x.LessonDescription)
                .NotEmpty().WithMessage("Lesson description is required.");
                
            RuleFor(x => x.CourseId)
                .GreaterThan(0).WithMessage("Course ID must be greater than 0.");
            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Created date cannot be in the future.");
        }
    }
}
