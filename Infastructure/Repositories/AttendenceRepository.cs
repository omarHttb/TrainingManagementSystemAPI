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

        public async Task<double> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId)
        {
            var result = await _context.Database
            .SqlQuery<double>($"EXEC SP_CalculateAttendancePercentagePerTrainee {enrollmentId}")
            .ToListAsync();

            return result.SingleOrDefault();
        }

        public async Task<bool> RecordAttendancePerLessonUsingSP(Attendence attendance)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                ($"EXEC SP_RecordAttendancePerLesson {attendance.EnrollmentId},{attendance.DidAttend}, {attendance.LessonId},{attendance.AttendanceDate} ");

            return rows > 0;
        }
    }
}
