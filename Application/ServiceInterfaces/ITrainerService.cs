using Application.DTOS.TrainersDTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface ITrainerService
    {
        Task<bool> CreateTrainerUsingSP(CreateTrainerDTO trainer);

        Task<bool> UpdateTrainerUsingSP(UpdateTrainerDTO updateTrainerDTO, int Id);

        Task<bool> DeleteTrainerUsingSP(int Id);

        Task<TrainerWithDetailsDTO> GetTrainerByIdUsingSP(int Id);

        Task<List<TrainerWithDetailsDTO>> GetAllTrainersUsingSP();

        Task<bool> SetActivateTrainerUsingSP(int TrainerId, bool isActive);

        Task<bool> SetVerifyTrainerUsingSP(int TrainerId, bool isVerified, int VerifiedById);

    }
}
