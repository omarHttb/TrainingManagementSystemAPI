using Application.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class AttendanceDTOValidator : AbstractValidator<CreateAttendanceDTO>
    {
        public AttendanceDTOValidator() 
        {
            RuleFor(x => x.DidAttend).NotEmpty();
            RuleFor(y => y.enrollmentId).NotEmpty();

        }
    }
}
