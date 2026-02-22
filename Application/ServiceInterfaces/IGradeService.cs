
using Application.DTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface IGradeService
    {
        Task<bool> AddTraineeGradeUsingSp(Grade grade);

        Task<AverageGradeForCourseDTO> GetAverageGradeForCourseUsingSp(int courseId);

        Task<bool> UpdateTraineeGradeUsingSp(Grade grade, int Id);
    }
}
