using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
    {

        public EnrollmentRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> EnrollTraineeIntoACourseUsingSp(Enrollment enrollment)
        {

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_EnrollTraineeToCourse", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@CourseId", SqlDbType.Int)
                   .Value = enrollment.CourseId;

            command.Parameters.Add("@TraineeId", SqlDbType.Int)
                   .Value = enrollment.TraineeId;
            command.Parameters.Add("@EnrollmentDate", SqlDbType.DateTime)
                   .Value = enrollment.EnrollmentDate;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }
    }
}
