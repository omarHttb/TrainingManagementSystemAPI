using Application.DTOS;
using Application.DTOS.TrainersDTOS;
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
    public class TrainerService : ITrainerService
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _mappers;
        private readonly IValidator<CreateTrainerDTO> _CreateTrainerValidater;
        private readonly IValidator<UpdateTrainerDTO> _UpdateTrainerValidater;

        public TrainerService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateTrainerDTO> CreateTrainerValidater, IValidator<UpdateTrainerDTO> updateTrainerValidater)
        {

            _UnitOfWork = unitOfWork;
            _mappers = mapper;
            _CreateTrainerValidater = CreateTrainerValidater;
            _UpdateTrainerValidater = updateTrainerValidater;
        }

        public async Task<bool> CreateTrainerUsingSP(CreateTrainerDTO trainerDTO)
        {
            await _CreateTrainerValidater.ValidateAndThrowAsync(trainerDTO);

            var trainer = _mappers.Map<Trainer>(trainerDTO);

            var result = await _UnitOfWork.TrainerRepository.CreateTrainerUsingSP(trainer);


            return result;
        }

        public async Task<bool> DeleteTrainerUsingSP(int Id)
        {
            var result = await _UnitOfWork.TrainerRepository.DeleteTrainerUsingSP(Id);



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

        public async Task<bool> SetActivateTrainerUsingSP(int TrainerId, bool isActive)
        {
            var result = await _UnitOfWork.TrainerRepository.SetActivateTrainerUsingSP(TrainerId, isActive);



            return result;
        }

        public async Task<bool> SetVerifyTrainerUsingSP(int TrainerId, bool isVerified,  int VerifiedById)
        {
           var VerifiedAt = DateTime.Now;
            var result = await _UnitOfWork.TrainerRepository.SetVerifyTrainerUsingSP(TrainerId, isVerified, VerifiedAt, VerifiedById);


            return result;
        }

        public async Task<bool> UpdateTrainerUsingSP(UpdateTrainerDTO updateTrainerDTO, int Id)
        {
            var ExistingTrainer = await _UnitOfWork.TrainerRepository.GetByIdAsync(Id);

            if (ExistingTrainer == null) throw new ArgumentException($"No trainer found with ID {Id}", nameof(Id));

            _UpdateTrainerValidater.ValidateAndThrow(updateTrainerDTO);

            var trainer = _mappers.Map<Trainer>(updateTrainerDTO);

            var result = await _UnitOfWork.TrainerRepository.UpdateTrainerUsingSP(trainer, Id);

          await  _UnitOfWork.CompleteAsync();

            return result;
        }
    }
}
