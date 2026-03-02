using Application.DTOS;
using Application.DTOS.CoursesDTOS;
using Application.DTOS.UsersDTOS;
using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
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

        public async Task<LoginDTO> Login(string email, string password)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_VerifyUserLogin", connection);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@Email", SqlDbType.NVarChar)
                    .Value = email;

            command.Parameters.Add("@InputPasswordHash", SqlDbType.NVarChar)
                    .Value = password;

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new LoginDTO
                {
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),

                };
            }
            else {
                return new LoginDTO();
            }
        }

        public async Task<List<string>> GetUserRoles(int userId)
        {
            List<string> result = new List<string>();

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetUserRoles", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@UserId", SqlDbType.Int)
                .Value = userId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(reader.GetString("RoleName"));
            }

            return result;


        }
    }
}

