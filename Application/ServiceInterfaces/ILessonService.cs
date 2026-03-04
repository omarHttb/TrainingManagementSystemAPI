using Application.DTOS.LessonsDTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface ILessonService
    {
        Task<List<LessonsDTO>> GetAllDetailedLessonsByCourseIdUsingSP(int courseId);

        Task<List<LessonsUserAttended>> GetAllLessonsUserAttendedUsingSP(int EnrollmentId);

        Task<bool> SetActivateLessonUsingSP(int lessonId, bool isActive);

        Task<List<AllCourseLessonsDTO>> GetAllCourseLessonsUsingSP(int courseId, int enrollmentId);

        Task<LessonsDTO> GetLessonByIdUsingSp(int lessonId);
    }
}
