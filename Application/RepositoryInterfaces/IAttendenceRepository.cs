using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IAttendenceRepository : IBaseRepository<Attendence>
    {

        Task<bool> RecordAttendancePerLessonUsingSP(Attendence attendance);

        Task<double> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId);
        
    }
}
