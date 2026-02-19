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
    public class TraineeRepository : BaseRepository<Trainee>, ITraineeRepository
    {

        public TraineeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public Task<bool> CreateTraineeUsingSP(Trainee trainee)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTraineeUsingSP(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Trainee>> GetAllTrainesWithPaginationUsingSP(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Trainee> SeachTraineeByEmailOrNameUsingSP(string name = "", string email = "")
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTraineeUsingSP(Trainee trainee, int Id)
        {
            throw new NotImplementedException();
        }
    }
}
