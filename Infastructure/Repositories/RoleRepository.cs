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
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {

        public RoleRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> AssignRoleToUserUsingSP(int userId, int roleId)
        {

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_AssignRoleToUser", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@UserId", SqlDbType.Int)
                .Value = userId;

            command.Parameters.Add("@RoleId", SqlDbType.Int)
                .Value = roleId;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }
    }
}
