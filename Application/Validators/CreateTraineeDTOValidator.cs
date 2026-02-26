using Application.DTOS.TraineeDTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class CreateTraineeDTOValidator : AbstractValidator<CreateTraineeDTO>
    {
        public CreateTraineeDTOValidator() 
        {
           
        }
    }
}
