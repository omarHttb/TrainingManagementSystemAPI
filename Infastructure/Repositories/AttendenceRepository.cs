using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    public class AttendenceRepository : BaseRepository<Attendence>, IAttendenceRepository
    {

        public AttendenceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<decimal> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId)
        {
            var percentage = await _context.Database.SqlQuery<decimal>
                ($"EXEC SP_CalculateAttendancePercentagePerTrainee {enrollmentId}").SingleAsync();

            return percentage;
        }

        public async Task<bool> RecordAttendancePerLessonUsingSP(Attendence attendance)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                ($"EXEC SP_RecordAttendancePerLesson {attendance.EnrollmentId},{attendance.DidAttend}, {attendance.LessonId},{attendance.AttendanceDate} ");

            return rows > 0;
        }
    }
}
