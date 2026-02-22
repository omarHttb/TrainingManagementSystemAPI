
using Application.DTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface ICourseService
    {

        Task<bool> CreateCourseUsingSP(Course course);

        Task<bool> UpdateCourseUsingSP(int Id, Course course);

        Task<bool> DeleteCourseUsingSP(int Id);

        Task<GetCourseDetailsDTO> GetCourseDetailsByIdUsingSP(int Id);

        Task<List<GetCourseDetailsDTO>> GetAllCourseDetailsUsingSP();

        Task<bool> SetCourseCpacityUsingSP(int Capacity, int Id);

        Task<bool> AssignTrainerToCourseUsingSP(int Id, int TrainerId);
    }
}
