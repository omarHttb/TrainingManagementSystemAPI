using Application.DTOS;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface ITrainerRepository : IBaseRepository<Trainer>
    {

        Task<bool> CreateTrainerUsingSP(Trainer trainer);

        Task<bool> UpdateTrainerUsingSP(string TeachingSubject, int Id);

        Task<bool> DeleteTrainerUsingSP(int Id);

        Task<TrainerWithDetailsDTO> GetTrainerByIdUsingSP(int Id);

        Task<List<TrainerWithDetailsDTO>> GetAllTrainersUsingSP();


    }
}
