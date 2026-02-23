using Application.DTOS;
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
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCourseDTO> _validator;
        private readonly IValidator<UpdateCourseDTO> _UpdateValidator;
        public CourseService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateCourseDTO> validator, IValidator<UpdateCourseDTO> UpdateValidator) 
        {
            _UnitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
            _UpdateValidator = UpdateValidator;
        }

        public async Task<bool> AssignTrainerToCourseUsingSP(int Id, int TrainerId)
        {
            if (Id <= 0) throw new ArgumentException("Course ID must be greater than 0", nameof(Id));
            if (TrainerId <= 0) throw new ArgumentException("Trainer ID must be greater than 0", nameof(TrainerId));


            var result = await _UnitOfWork.CourseRepository.AssignTrainerToCourseUsingSP(Id, TrainerId);

           await _UnitOfWork.CompleteAsync();

            return result;
        }

        public async Task<bool> CreateCourseUsingSP(CreateCourseDTO courseDTO)
        {
            await _validator.ValidateAndThrowAsync(courseDTO);

            var course = _mapper.Map<Course>(courseDTO);    

            var result = await _UnitOfWork.CourseRepository.CreateCourseUsingSP(course);

          await  _UnitOfWork.CompleteAsync();

            return  result;
        }

        public async Task<bool> DeleteCourseUsingSP(int id)
        {
            if (id <= 0) throw new ArgumentException("Course ID must be greater than 0", nameof(id));

            var result = await _UnitOfWork.CourseRepository.DeleteCourseUsingSP(id);

          await  _UnitOfWork.CompleteAsync();

            return result;
        }

        public async Task<List<GetCourseDetailsDTO>> GetAllCourseDetailsUsingSP()
        {
            return await _UnitOfWork.CourseRepository.GetAllCourseDetailsUsingSP();
        }

        public async Task<GetCourseDetailsDTO> GetCourseDetailsByIdUsingSP(int id)
        {
           return await _UnitOfWork.CourseRepository.GetCourseDetailsByIdUsingSP(id);
        }

        public async Task<bool> SetCourseCpacityUsingSP(int Capacity, int id)
        {
            if (id <= 0) throw new ArgumentException("Course ID must be greater than 0", nameof(id));
            if (Capacity <= 0) throw new ArgumentException("Trainer ID must be greater than 0", nameof(Capacity));

            var result = await _UnitOfWork.CourseRepository.SetCourseCpacityUsingSP(Capacity, id);

           await _UnitOfWork.CompleteAsync();

            return result;
        }

        public async Task<bool> UpdateCourseUsingSP(int id, UpdateCourseDTO courseDTO)
        {


            var existingCourse = await _UnitOfWork.CourseRepository.GetByIdAsync(id);

            if (existingCourse == null)
                return false;
            if(existingCourse.TrainerId > 0)
            {
                throw new ArgumentException("a Trainer is already assigned to this course", nameof(existingCourse.TrainerId));
            }

            await _UpdateValidator.ValidateAndThrowAsync(courseDTO);


            _mapper.Map(courseDTO, existingCourse);

            var result = await _UnitOfWork.CourseRepository.UpdateCourseUsingSP(id, existingCourse);

            await _UnitOfWork.CompleteAsync();

            return result;
        }
    }
}
