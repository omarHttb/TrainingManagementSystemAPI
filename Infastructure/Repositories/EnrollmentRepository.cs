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
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {

        public EnrollmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> EnrollTraineeIntoACourseUsingSp(Enrollment enrollment)
        {

            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                ($"EXEC SP_EnrollTraineeToCourse {enrollment.CourseId} , {enrollment.TraineeId}, {enrollment.EnrollmentDate}");

            return rows > 0;
        }
    }
}
