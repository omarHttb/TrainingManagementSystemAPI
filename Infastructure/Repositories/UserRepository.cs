using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> RegisterUserUsingSP(User user)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_CreateNewUser", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@FirstName", SqlDbType.NVarChar)
                .Value = user.FirstName;

            command.Parameters.Add("@LastName", SqlDbType.NVarChar)
                .Value = user.LastName;

            command.Parameters.Add("@Gender", SqlDbType.Decimal)
                .Value = user.Gender;

            command.Parameters.Add("@DateOfBirth", SqlDbType.DateTime)
                .Value = user.DateOfBirth;

            command.Parameters.Add("@UserCreationDate", SqlDbType.Int)
                .Value = user.UserCreationDate;

            command.Parameters.Add("@PasswordHash", SqlDbType.Int)
                .Value = user.PasswordHash;

            await connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }

        public async Task<bool> DoesEmailExist(string email, int? excludePersonId = null)
        {
            var query = _dbSet.Where(p => p.Email == email);

            if (excludePersonId.HasValue)
                query = query.Where(p => p.Id != excludePersonId);

            return await query.AnyAsync();
        }
    }
}

