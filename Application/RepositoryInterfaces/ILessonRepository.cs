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

        Task<List<LessonsDTO>> GetAllLessonsByCourseId(int courseId);

        Task<List<LessonsUserAttended>> GetAllLessonsUserAttended(int enrollmentId);

        Task<bool> SetActivateLesson(int lessonId,bool isActive);
        
    }
}
