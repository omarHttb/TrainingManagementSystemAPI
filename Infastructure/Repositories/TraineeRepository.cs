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
    public class TraineeRepository : BaseRepository<Trainee>, ITraineeRepository
    {

        public TraineeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> CreateTraineeUsingSP(Trainee trainee)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                ($"EXEC SP_CreateTrainee {trainee.UserId},{trainee.JoinDate}");

            return rows > 0;

        }

        public async Task<bool> DeleteTraineeUsingSP(int id)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync("EXEC SP_DeleteTrainee @Id",
                        new SqlParameter("@Id", id));

            return rows > 0;
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
