
using Application.DTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface IAttendenceService
    {

        Task<bool> RecordAttendancePerLessonUsingSP(CreateAttendanceDTO attendance);

        Task<decimal> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId);
    }
}
