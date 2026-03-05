using Application.DTOS.AttendanceDTOS;
using Application.DTOS.AttendancesDTOS;
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
        private readonly IValidator<UpdateAttendanceDTO> _UpdateValidator;

        public AttendenceService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateAttendanceDTO> validator
            , IValidator<UpdateAttendanceDTO> UpdateValidator) 
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _UpdateValidator = UpdateValidator;
        }

        public async Task<double> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId)
        { 

            return await _UnitOfWork.AttendenceRepository.CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(enrollmentId);
        }

        public async Task<List<AttendanceCourseReportDTO>> GetAttendanceReportForACourseUsingSP(int courseId)
        {
            return await _UnitOfWork.AttendenceRepository.GetAttendanceReportForACourseUsingSP(courseId);   
        }

        public async Task<bool> RecordAttendancePerLessonUsingSP(CreateAttendanceDTO attendanceDTO)
        {
            await _validator.ValidateAndThrowAsync(attendanceDTO);

            var attendance = _mapper.Map<Attendence>(attendanceDTO);

            var result = await _UnitOfWork.AttendenceRepository.RecordAttendancePerLessonUsingSP(attendance);


            return result;
        }

        public async Task<bool> UpdateAttendanceUsingSP(UpdateAttendanceDTO updateAttendanceDTO)
        {
            await _UpdateValidator.ValidateAndThrowAsync(updateAttendanceDTO);

            var attendance = _mapper.Map<Attendence>(updateAttendanceDTO);

            var result = await _UnitOfWork.AttendenceRepository.UpdateAttendanceUsingSP(attendance);

            return result;
        }
    }
}
