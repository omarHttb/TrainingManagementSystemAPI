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
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mappers;
        public TrainerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _UnitOfWork = unitOfWork;
            _mappers = mapper;
        }

        public async Task<bool> CreateTrainerUsingSP(CreateTrainerDTO trainerDTO)
        {

            if (trainerDTO.TeachingSubject == "" || trainerDTO.TeachingSubject == null) throw new ArgumentException("Trainer must have a teaching subject");

            var trainer = _mappers.Map<Trainer>(trainerDTO);

            var result = await _UnitOfWork.TrainerRepository.CreateTrainerUsingSP(trainer);

            await _UnitOfWork.CompleteAsync();

            return result;
        }

        public Task<bool> DeleteTrainerUsingSP(int Id)
        {
            var result = _UnitOfWork.TrainerRepository.DeleteTrainerUsingSP(Id);

            return result;
        }

        public Task<List<TrainerWithDetailsDTO>> GetAllTrainersUsingSP()
        {
           return _UnitOfWork.TrainerRepository.GetAllTrainersUsingSP();
        }

        public Task<TrainerWithDetailsDTO> GetTrainerByIdUsingSP(int Id)
        {
            return _UnitOfWork.TrainerRepository.GetTrainerByIdUsingSP(Id);
        }

        public async Task<bool> UpdateTrainerTeachingSubjectUsingSP(string TeachingSubject, int Id)
        {
            var ExistingTrainer = await _UnitOfWork.TrainerRepository.GetByIdAsync(Id);

            if (ExistingTrainer == null)
                return false;
            

            if (TeachingSubject == "" || TeachingSubject == null) throw new ArgumentException("Trainer must have a teaching subject");


            var result = await _UnitOfWork.TrainerRepository.UpdateTrainerUsingSP(TeachingSubject, Id);


            return result;
        }
    }
}
