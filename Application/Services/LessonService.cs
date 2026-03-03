using Application.DTOS.LessonsDTOS;
using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class LessonService : ILessonService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public LessonService(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public Task<List<LessonsDTO>> GetAllLessonsByCourseId(int courseId)
        {
            return _UnitOfWork.LessonRepository.GetAllLessonsByCourseId(courseId);
        }

        public async Task<List<LessonsUserAttended>> GetAllLessonsUserAttended(int EnrollmentId)
        {
            return await _UnitOfWork.LessonRepository.GetAllLessonsUserAttended(EnrollmentId);
        }

        public async Task<bool> SetActivateLesson(int lessonId, bool isActive)
        {
            var result = await _UnitOfWork.LessonRepository.SetActivateLesson(lessonId, isActive);

            return result;
        }
    }
}
