using Application.DTOS;
using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
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

        public Task<Grade> AddGrade(Grade grade)
        {
            throw new NotImplementedException();
        }

        public Task<AverageGradeForCourseDTO> GetAverageGradeForCourse(int courseId)
        {
            throw new NotImplementedException();
        }

        public Task<Grade> UpdateGrade(Grade grade, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
