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

        public Task<List<LessonsUserAttended>> GetAllLessonsUserAttended(int EnrollmentId)
        {
            return _UnitOfWork.LessonRepository.GetAllLessonsUserAttended(EnrollmentId);
        }
    }
}
