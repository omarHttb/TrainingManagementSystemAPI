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
        Task<List<LessonsDTO>> GetAllLessonsByCourseId(int courseId);

        Task<List<LessonsUserAttended>> GetAllLessonsUserAttended(int EnrollmentId);

    }
}
