using Application.Models;
using Application.ServiceInterfaces;
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
        public AttendenceService(IUnitOfWork unitOfWork) 
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task<decimal> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId)
        { 

            return await _UnitOfWork.AttendenceRepository.CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(enrollmentId);
        }

        public async Task<bool> RecordAttendancePerLessonUsingSP(Attendence attendance)
        {
            var result = await _UnitOfWork.AttendenceRepository.RecordAttendancePerLessonUsingSP(attendance);

          await  _UnitOfWork.CompleteAsync();

            return result;
        }
    }
}
