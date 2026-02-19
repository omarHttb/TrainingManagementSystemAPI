using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    public class TrainerRepository : BaseRepository<Trainer>, ITrainerRepository
    {

        public TrainerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public Task<bool> CreateTrainerUsingSP(Trainer trainer)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTrainerUsingSP(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Trainer>> GetAllTrainersUsingSP()
        {
            throw new NotImplementedException();
        }

        public Task<Trainer> GetTrainerByIdUsingSP(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTrainerUsingSP(Trainer trainer, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
