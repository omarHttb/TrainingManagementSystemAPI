using Application.DTOS;
using Application.Models;
using Application.ServiceInterfaces;
using AutoMapper;
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
        public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> EnrollTraineeIntoACourseUsingSp(CreateEnrollmentDTO enrollmentDTO)
        {
            var enrollment = _mapper.Map<Enrollment>(enrollmentDTO);

            var result = await _UnitOfWork.EnrollmentRepository.EnrollTraineeIntoACourseUsingSp(enrollment);

            await _UnitOfWork.CompleteAsync();

            return result;
        }
    }
}
