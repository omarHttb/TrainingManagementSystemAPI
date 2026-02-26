using Application.DTOS;
using Application.DTOS.CoursesDTOS;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {

        Task<bool> CreateCourseUsingSP(Course course);

        Task<bool> UpdateCourseUsingSP(int Id, Course course);

        Task<bool> DeleteCourseUsingSP(int Id);

        Task<GetCourseDetailsDTO> GetCourseDetailsByIdUsingSP (int Id);

        Task<List<GetCourseDetailsDTO>> GetAllCourseDetailsUsingSP();

        Task<bool> SetCourseCpacityUsingSP(int Capacity, int Id);

        Task<bool> AssignTrainerToCourseUsingSP(int Id, int TrainerId);

        Task<List<GetAllTraineeCoursesDTO>> GetAllTraineeCoursesUsingSP(int TraineeId);

        Task<List<GetAllTraineesEnrolledInACourseDTO>> GetAllTraineesEnrolledInACourseUsingSP(int CourseId);
    }
}
