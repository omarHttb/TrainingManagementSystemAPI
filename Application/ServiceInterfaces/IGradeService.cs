
using Application.DTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface IGradeService
    {
        Task<bool> AddTraineeGradeUsingSp(AddTraineeGradeDTO grade);

        Task<AverageGradeForCourseDTO> GetAverageGradeForCourseUsingSp(int courseId);

        Task<bool> UpdateTraineeGradeUsingSp(decimal grade, int Id);
    }
}
