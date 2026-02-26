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
    public class AttendenceRepository : BaseRepository<Attendence>, IAttendenceRepository
    {

        public AttendenceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<double> CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(int enrollmentId)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_CalculateAttendancePercentagePerTrainee", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@EnrollmentId", SqlDbType.Int)
                                    .Value = enrollmentId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if(await reader.ReadAsync())
            {
                return reader.GetDouble(reader.GetOrdinal("AttendancePercentage"));
            }

            throw new Exception("Failed to calculate attendance percentage.");
        }

        public async Task<bool> RecordAttendancePerLessonUsingSP(Attendence attendance)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_AddGradeForTrainee", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@EnrollmentId", SqlDbType.Int)
                                    .Value = attendance.EnrollmentId;
            command.Parameters.Add("@DidAttend", SqlDbType.Bit)
                                    .Value = attendance.DidAttend;
            command.Parameters.Add("@LessonId", SqlDbType.Int)
                                    .Value = attendance.LessonId;
            command.Parameters.Add("@AttendanceDate", SqlDbType.Date)
                                    .Value = attendance.AttendanceDate;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }
    }
}
