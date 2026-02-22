
using Application.DTOS;
using Application.Models;

namespace Application.ServiceInterfaces
{
    public interface ITrainerService
    {
        Task<bool> CreateTrainerUsingSP(Trainer trainer);

        Task<bool> UpdateTrainerUsingSP(Trainer trainer, int Id);

        Task<bool> DeleteTrainerUsingSP(int Id);

        Task<TrainerWithDetailsDTO> GetTrainerByIdUsingSP(int Id);

        Task<List<TrainerWithDetailsDTO>> GetAllTrainersUsingSP();
    }
}
