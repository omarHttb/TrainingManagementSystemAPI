using Application.DTOS.AttendancesDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class UpdateAttendanceValidator : AbstractValidator<UpdateAttendanceDTO>
    {
        public UpdateAttendanceValidator() 
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage(" ID must be greater than 0.");   
            RuleFor(x => x.DidAttend)
                .NotNull().WithMessage("IsAttended field is required.");

        }
    }
}
