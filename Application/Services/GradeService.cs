using Application.DTOS;
using Application.DTOS.GradesDTOS;
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
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper    _Mapper;
        private readonly IValidator<AddTraineeGradeDTO> _validator;

        public GradeService(IUnitOfWork unitOfWork , IMapper mapper, IValidator<AddTraineeGradeDTO> validator) 
        {
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
            _validator = validator;
        }

        public async Task<bool> AddTraineeGradeUsingSp(AddTraineeGradeDTO gradeDTO)
        {
            var doesTraineeGradeExist = _UnitOfWork.GradeRepository.FindAsync(g => g.EnrollmentId == gradeDTO.EnrollmentId);

            if (doesTraineeGradeExist != null)
            {
                throw new ArgumentException("Grade already added for this entrollment ID must be greater than 0");
            }

            var grade = _Mapper.Map<Grade>(gradeDTO);

            //if (grade.Grade1 >= 50) 
            //{f
            //    grade.IsPass = true;
            //}
            //else
            //{
            //    grade.IsPass = false;
            //}

            var result = await _UnitOfWork.GradeRepository.AddTraineeGradeUsingSp(grade);

            await _UnitOfWork.CompleteAsync();

            return result;

        }

        public async Task<AverageGradeForCourseDTO> GetAverageGradeForCourseUsingSp(int courseId)
        {
            var averageGrade = await _UnitOfWork.GradeRepository.GetAverageGradeForCourseUsingSp(courseId);

            return averageGrade;
        }

        public async Task<bool> UpdateTraineeGradeUsingSp(decimal TraineeNewGrade, int Id)
        {
            var grade = await _UnitOfWork.GradeRepository.GetByIdAsync(Id);

            if (grade == null)
            {
                new ArgumentException("Grade Id is null");
            }
            if(TraineeNewGrade <= 0)
            {
                new ArgumentException("Grade must be greater than or equal to 0");
            }

            var result = await _UnitOfWork.GradeRepository.UpdateTraineeGradeUsingSp(TraineeNewGrade, Id);


            return result;

        }
    }
}
