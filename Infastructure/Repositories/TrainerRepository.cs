using Application.DTOS.CoursesDTOS;
using Application.DTOS.TrainersDTOS;
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
    public class TrainerRepository : BaseRepository<Trainer>, ITrainerRepository
    {

        public TrainerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> CreateTrainerUsingSP(Trainer trainer)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_CreateTrainer", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@UserId", SqlDbType.Int)
                .Value = trainer.UserId;

            command.Parameters.Add("@TeachingSubject", SqlDbType.NVarChar)
                .Value = trainer.TeachingSubject;

            command.Parameters.Add("@JoinDate", SqlDbType.Decimal)
                .Value = trainer.JoinDate;

            command.Parameters.Add("@Headline", SqlDbType.NVarChar)
                .Value = trainer.Headline;

            command.Parameters.Add(" @Bio", SqlDbType.NVarChar)
                .Value = trainer.Bio;

            command.Parameters.Add("@YearsOfExperiance", SqlDbType.SmallInt)
                .Value = trainer.YearsOfExperiance;

            await connection.OpenAsync();
               

            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;
        
        }

        public async Task<bool> DeleteTrainerUsingSP(int Id)
        {

           
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_DeleteTrainer", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int)
                .Value = Id;

            await connection.OpenAsync();


            var rowsAffected = await command.ExecuteNonQueryAsync();
            return rowsAffected > 0;

        }

        public async Task<List<TrainerWithDetailsDTO>> GetAllTrainersUsingSP()
        {
            var result = new List<TrainerWithDetailsDTO>();

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllTrainerDetails", connection);

            command.CommandType = CommandType.StoredProcedure;


            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new TrainerWithDetailsDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FullName = reader.GetString(reader.GetOrdinal("fullName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    TeachingSubject = reader.GetString(reader.GetOrdinal("TeachingSubject")),
                    JoinDate = reader.GetDateTime(reader.GetOrdinal("JoinDate")),
                    Headline = reader.GetString(reader.GetOrdinal("Headline")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    IsVerified = reader.GetBoolean(reader.GetOrdinal("IsVerified")),
                });
            }

            return result;
        }

        public async Task<TrainerWithDetailsDTO> GetTrainerByIdUsingSP(int Id)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetCourseDetails", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int)
                   .Value = Id;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new TrainerWithDetailsDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    FullName = reader.GetString(reader.GetOrdinal("fullName")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    TeachingSubject = reader.GetString(reader.GetOrdinal("TeachingSubject")),
                    JoinDate = reader.GetDateTime(reader.GetOrdinal("JoinDate")),
                    Headline = reader.GetString(reader.GetOrdinal("Headline")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    IsVerified = reader.GetBoolean(reader.GetOrdinal("IsVerified")),
                };
            }

            return new TrainerWithDetailsDTO();
        }

        public async Task<bool> SetActivateTrainerUsingSP(int TrainerId, bool isActive)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_ActivateTrainer", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Activate", SqlDbType.Bit)
            .Value = isActive;
            command.Parameters.Add("@TrainerId", SqlDbType.Int)
            .Value = TrainerId  ;

            await connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> SetVerifyTrainerUsingSP(int TrainerId, bool isVerified, DateTime VerifiedAt, int VerifiedById)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_VerifyTrainer", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Verify", SqlDbType.Bit)
            .Value = isVerified;
            command.Parameters.Add("@VerifiedAt", SqlDbType.DateTime)
            .Value = VerifiedAt;
            command.Parameters.Add("@TrainerId", SqlDbType.Int)
           .Value = TrainerId;
            command.Parameters.Add("@VerifiedBy", SqlDbType.Int)
           .Value = VerifiedById;

            await connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }

        public async Task<bool> UpdateTrainerUsingSP(Trainer trainer, int Id)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_UpdateTrainer", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.Int)
            .Value = Id;
            command.Parameters.Add("@TeachingSubject", SqlDbType.NVarChar)
            .Value = trainer.TeachingSubject;

            command.Parameters.Add("@YearsOfExperiance", SqlDbType.SmallInt)
            .Value = trainer.YearsOfExperiance;
            command.Parameters.Add("@Headline", SqlDbType.NVarChar)
            .Value = trainer.Headline;
            command.Parameters.Add("@Bio", SqlDbType.NVarChar)
            .Value = trainer.Bio;

            await connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }
    }
}
