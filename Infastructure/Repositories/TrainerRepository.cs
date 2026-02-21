using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateTrainerUsingSP(Trainer trainer)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
        ($"EXEC SP_CreateTrainer {trainer.UserId},{trainer.TeachingSubject},{trainer.JoinDate}");

            return rows > 0;
        }

        public async Task<bool> DeleteTrainerUsingSP(int Id)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync("EXEC SP_DeleteTrainer @Id",
            new SqlParameter("@Id", Id));

            return rows > 0;

        }

        public Task<List<Trainer>> GetAllTrainersUsingSP()
        {
            //TODO COMPLETE THESE
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
