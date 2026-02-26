using Application.DTOS.AttendanceDTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface IAttendenceService
    {

        Task<bool> RecordAttendancePerLessonUsingSP(CreateAttendanceDTO attendance);

        Task<double> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId);
    }
}
