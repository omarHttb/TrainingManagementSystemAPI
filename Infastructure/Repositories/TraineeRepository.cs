using Application.DTOS;
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

        public async Task<List<TraineeDetailsDTO>> GetAllTrainesWithPaginationUsingSP(int pageNumber, int pageSize)
        {
            var result = await _context.TraineeDetailsDTO
                    .FromSqlInterpolated($"EXEC SP_GetPaginatedTrainees {pageNumber}, {pageSize}")
                    .ToListAsync();

            return result;

        }

        public async Task<List<TraineeDetailsDTO>> SeachTraineeByEmailOrNameUsingSP(string FirstName = "",string LastName="", string email = ""
            )
        {
            var results = await _context.TraineeDetailsDTO.FromSqlInterpolated(
                     $"EXEC SP_GetTraineesByNameOrEmail @FirstName={FirstName}, @LastName={LastName}, @Email={email}")
                 .ToListAsync();

            return results;
        }

        public async Task<bool> UpdateTraineeUsingSP(Trainee trainee, int Id)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                ($"EXEC SP_UpdateTrainee {Id},{trainee.UserId},{trainee.JoinDate}");

            return rows > 0;

        }
    }
}
