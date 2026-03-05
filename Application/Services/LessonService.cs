using Application.DTOS.LessonsDTOS;
using Application.Models;
using Application.ServiceInterfaces;
using AutoMapper;
using FluentValidation;
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
        private readonly IMapper _mapper;
        private readonly IValidator<CreateLessonDTO> _validator;
        private readonly IValidator<UpdateLessonDTO> _updateValidator;
        public LessonService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateLessonDTO> validator, IValidator<UpdateLessonDTO> updateValidator)
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _updateValidator = updateValidator;
        }

        public async Task<bool> CreateLessonUsingSP(CreateLessonDTO lessonDTO)
        {
            await _validator.ValidateAndThrowAsync(lessonDTO);

            var lesson = _mapper.Map<Lesson>(lessonDTO);

            return await _UnitOfWork.LessonRepository.CreateLessonUsingSP(lesson);
        }

        public async Task<List<AllCourseLessonsDTO>> GetAllActiveCourseLessonsUsingSP(int courseId, int enrollmentId)
        {
            var enrollment = await _UnitOfWork.EnrollmentRepository.GetByIdAsync(enrollmentId);

            if(enrollment == null )
            {
                throw new ArgumentException("Invalid enrollment ID for the specified course.");
            }

            return await _UnitOfWork.LessonRepository.GetAllActiveCourseLessonsUsingSP(courseId, enrollmentId);
        }

        public async Task<List<AllCourseLessonsDTO>> GetAllCourseLessonsUsingSP(int courseId, int enrollmentId)
        {
            var enrollment = await _UnitOfWork.EnrollmentRepository.GetByIdAsync(enrollmentId);

            if (enrollment == null)
            {
                throw new ArgumentException("Invalid enrollment ID for the specified course.");
            }

            return await _UnitOfWork.LessonRepository.GetAllCourseLessonsUsingSP(courseId, enrollmentId);
        }

        public async Task<List<LessonsDTO>> GetAllDetailedLessonsByCourseIdUsingSP(int courseId)
        {
            return await _UnitOfWork.LessonRepository.GetAllDetailedLessonsByCourseIdUsingSP(courseId);
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

        public async Task<bool> UpdateLessonUsingSP(UpdateLessonDTO updateLessonDTO)
        {
             await _updateValidator.ValidateAndThrowAsync(updateLessonDTO);

            var updatedLesson = _mapper.Map<Lesson>(updateLessonDTO);


            var result = await _UnitOfWork.LessonRepository.UpdateLessonUsingSP(updatedLesson);

            return result;

        }
    }
}
