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

        Task<bool> UpdateTrainerUsingSP(Trainer trainer, int Id);

        Task<bool> DeleteTrainerUsingSP(int Id);

        Task<Trainer> GetTrainerByIdUsingSP(int Id);

        Task<List<Trainer>> GetAllTrainersUsingSP();


    }
}
