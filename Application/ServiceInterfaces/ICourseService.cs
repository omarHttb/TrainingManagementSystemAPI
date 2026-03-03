
using Application.DTOS;
using Application.DTOS.CoursesDTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface ICourseService
    {

        Task<bool> CreateCourseUsingSP(CreateCourseDTO course);

        Task<bool> UpdateCourseUsingSP(int id, UpdateCourseDTO course);

        Task<bool> DeleteCourseUsingSP(int id);

        Task<GetCourseDetailsDTO> GetCourseDetailsByIdUsingSP(int id);

        Task<List<GetCourseDetailsDTO>> GetAllCourseDetailsUsingSP();

        Task<bool> SetCourseCpacityUsingSP(int Capacity, int id);

        Task<bool> AssignTrainerToCourseUsingSP(int id, int TrainerId);

        Task<List<GetAllTraineesEnrolledInACourseDTO>> GetAllTraineesEnrolledInACourseUsingSP(int CourseId);


        Task<bool> SetActivateCourse(int CourseId, bool isActive);

        Task<bool> SetVerifyCourse(int CourseId, bool isVerified, int VerifiedById);

    }
}
