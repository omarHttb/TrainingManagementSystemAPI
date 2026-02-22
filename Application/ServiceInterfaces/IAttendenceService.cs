
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface IAttendenceService
    {

        Task<bool> RecordAttendancePerLessonUsingSP(Attendence attendance);

        Task<decimal> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId);
    }
}
