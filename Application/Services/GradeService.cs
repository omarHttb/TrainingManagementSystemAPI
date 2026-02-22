using Application.DTOS;
using Application.Models;
using Application.ServiceInterfaces;
using AutoMapper;
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
        public GradeService(IUnitOfWork unitOfWork , IMapper mapper) 
        {
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        public async Task<bool> AddTraineeGradeUsingSp(AddTraineeGradeDTO gradeDTO)
        {
            var grade = _Mapper.Map<Grade>(gradeDTO);

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
                return false;
            }

            var result = await _UnitOfWork.GradeRepository.UpdateTraineeGradeUsingSp(TraineeNewGrade, Id);


            return result;

        }
    }
}
