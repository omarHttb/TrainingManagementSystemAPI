using Application.DTOS.EnrollmensDTOS;
using Application.Models;
using Application.ServiceInterfaces;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateEnrollmentDTO> _validator;

        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateEnrollmentDTO> validator) 
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> EnrollTraineeIntoACourseUsingSp(CreateEnrollmentDTO enrollmentDTO)
        {
    
            await _validator.ValidateAndThrowAsync(enrollmentDTO);
             
            var enrollment = _mapper.Map<Enrollment>(enrollmentDTO);

            var result = await _UnitOfWork.EnrollmentRepository.EnrollTraineeIntoACourseUsingSp(enrollment);

            await _UnitOfWork.CompleteAsync();

            return result;
        }
    }
}
