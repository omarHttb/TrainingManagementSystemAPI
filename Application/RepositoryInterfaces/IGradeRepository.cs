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

        Task<bool> AddTraineeGradeUsingSp(Grade grade);

        Task<AverageGradeForCourseDTO> GetAverageGradeForCourseUsingSp(int courseId);

        Task<bool> UpdateTraineeGradeUsingSp(decimal TraineeNewGrade, int Id);
    }
}
