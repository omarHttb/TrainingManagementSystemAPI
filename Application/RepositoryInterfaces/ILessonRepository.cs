using Application.DTOS.LessonsDTOS;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface ILessonRepository : IBaseRepository<Lesson>
    {

        Task<List<LessonsDTO>> GetAllLessonsByCourseIdUsingSP(int courseId);

        Task<List<LessonsUserAttended>> GetAllLessonsUserAttendedUsingSP(int enrollmentId);

        Task<bool> SetActivateLessonUsingSP(int lessonId,bool isActive);

        Task<List<AllCourseLessonsDTO>> GetAllCourseLessonsUsingSP(int courseId);

        Task<LessonsDTO> GetLessonByIdUsingSp (int lessonId);      
    }
}
