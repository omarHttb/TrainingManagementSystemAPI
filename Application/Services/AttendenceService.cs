using Application.DTOS;
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
    public class AttendenceService : IAttendenceService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateAttendanceDTO> _validator;

        public AttendenceService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateAttendanceDTO> validator) 
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<double> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId)
        { 

            return await _UnitOfWork.AttendenceRepository.CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(enrollmentId);
        }

        public async Task<bool> RecordAttendancePerLessonUsingSP(CreateAttendanceDTO attendanceDTO)
        {
            await _validator.ValidateAndThrowAsync(attendanceDTO);

            var attendance = _mapper.Map<Attendence>(attendanceDTO);

            var result = await _UnitOfWork.AttendenceRepository.RecordAttendancePerLessonUsingSP(attendance);

            await  _UnitOfWork.CompleteAsync();

            return result;
        }
    }
}
