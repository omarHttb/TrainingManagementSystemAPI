using Application.DTOS;
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
    public class GradeRepository : BaseRepository<Grade>, IGradeRepository
    {

        public GradeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> AddTraineeGradeUsingSp(Grade grade)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_AddGradeForTrainee", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@EnrollmentId", SqlDbType.Int)
                   .Value = grade.EnrollmentId;

            command.Parameters.Add("@Grade", SqlDbType.Decimal)
                   .Value = grade.Grade1;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;


        }

        public async Task<AverageGradeForCourseDTO> GetAverageGradeForCourseUsingSp(int courseId)
        {

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAverageGradeForCourse", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@courseId", SqlDbType.Int)
                   .Value = courseId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new AverageGradeForCourseDTO
                {
                    CourseName = reader.GetString(reader.GetOrdinal("CourseName")),
                    AverageGrade = reader.GetDouble(reader.GetOrdinal("AverageGrade")),
                    TotalGrades = reader.GetInt32(reader.GetOrdinal("TotalGrades"))
                };
            }

            return new AverageGradeForCourseDTO();
        }

        public async Task<bool> UpdateTraineeGradeUsingSp(decimal TraineeNewGrade, int Id)
        {

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_UpdateGradeForTrainee", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int)
                   .Value = Id;

            command.Parameters.Add("@Grade", SqlDbType.Decimal)
                   .Value = TraineeNewGrade;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;


        }
    }
}
