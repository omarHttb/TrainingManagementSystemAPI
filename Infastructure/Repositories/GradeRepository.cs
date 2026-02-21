using Application.DTOS;
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
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {

        public GradeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> AddTraineeGradeUsingSp(Grade grade)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
             ($"EXEC SP_AddGradeForTrainee {grade.EnrollmentId} , {grade.Grade1}");

            return rows > 0;

        }

        public async Task<AverageGradeForCourseDTO> GetAverageGradeForCourseUsingSp(int courseId)
        {
            var averageGrade = await _context.Database
                .SqlQuery<AverageGradeForCourseDTO>(
                    $"EXEC SP_GetAverageGradeForCourse @courseId = {courseId}")
                .SingleAsync();

            return averageGrade;
        }

        public async Task<bool> UpdateTraineeGradeUsingSp(Grade grade, int Id)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC SP_UpdateGradeForTrainee {Id}, {grade.Grade1}");

            return rows > 0;    
        }
    }
}
