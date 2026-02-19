using Application.DTOS;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IGradeRepository : IBaseRepository<Grade>
    {

        Task<Grade> AddGrade(Grade grade);

        Task<AverageGradeForCourseDTO> GetAverageGradeForCourse(int courseId);

        Task<Grade> UpdateGrade(Grade grade , int Id);
    }
}
