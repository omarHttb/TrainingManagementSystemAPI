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

        public async Task<List<AllCourseLessonsDTO>> GetAllCourseLessonsUsingSP(int courseId)
        {
            return await _UnitOfWork.LessonRepository.GetAllCourseLessonsUsingSP(courseId);
        }

        public async Task<List<LessonsDTO>> GetAllLessonsByCourseIdUsingSP(int courseId)
        {
            return await _UnitOfWork.LessonRepository.GetAllLessonsByCourseIdUsingSP(courseId);
        }

        public async Task<List<LessonsUserAttended>> GetAllLessonsUserAttendedUsingSP(int EnrollmentId)
        {
            return await _UnitOfWork.LessonRepository.GetAllLessonsUserAttendedUsingSP(EnrollmentId);
        }

        public async Task<LessonsDTO> GetLessonByIdUsingSp(int lessonId)
        {
            return await _UnitOfWork.LessonRepository.GetLessonByIdUsingSp(lessonId);
        }

        public async Task<bool> SetActivateLessonUsingSP(int lessonId, bool isActive)
        {
            var result = await _UnitOfWork.LessonRepository.SetActivateLessonUsingSP(lessonId, isActive);

            return result;
        }
    }
}
