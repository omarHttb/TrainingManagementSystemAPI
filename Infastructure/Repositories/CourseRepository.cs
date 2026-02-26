using Application.DTOS;
using Application.DTOS.CoursesDTOS;
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
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {

        public CourseRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        public async Task<bool> AssignTrainerToCourseUsingSP(int Id, int TrainerId)
        {

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_AssignTrainerToCourse", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int)
               .Value = Id;

            command.Parameters.Add("@TrainerId", SqlDbType.Int)
                   .Value = TrainerId;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> CreateCourseUsingSP(Course course)
        {

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_CreateCourse", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Title", SqlDbType.NVarChar)
                .Value = course.Title;

            command.Parameters.Add("@Description", SqlDbType.NVarChar)
                .Value = course.Description;

            command.Parameters.Add("@Price", SqlDbType.Decimal)
                .Value = course.Price;

            command.Parameters.Add("@CreationDate", SqlDbType.DateTime)
                .Value = course.Description;

            command.Parameters.Add("@TrainerId", SqlDbType.Int)
                .Value = course.TrainerId;

            command.Parameters.Add("@Capacity", SqlDbType.Int)
                .Value = course.Capacity;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<bool> DeleteCourseUsingSP(int Id)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_DeleteCourse", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int)
                .Value = Id;

            await connection.OpenAsync();
            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }

        public async Task<List<GetCourseDetailsDTO>> GetAllCourseDetailsUsingSP()
        {
            var result = new List<GetCourseDetailsDTO>();

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllCoursesDetails", connection);

            command.CommandType = CommandType.StoredProcedure;


            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while( await reader.ReadAsync())
            {
                result.Add(new GetCourseDetailsDTO
                {
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                    CourseTitle = reader.GetString(reader.GetOrdinal("Title")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                    TrainerName = reader.GetString(reader.GetOrdinal("TrainerName")),
                    Capacity = reader.GetInt32(reader.GetOrdinal("Capacity"))
                });
            }

            return result;
        }

        public async Task<List<GetAllTraineeCoursesDTO>> GetAllTraineeCoursesUsingSP(int TraineeId)
        {
            var result = new List<GetAllTraineeCoursesDTO>();

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllTraineeCourses", connection);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@TraineeId", SqlDbType.Int)
                .Value = TraineeId;



            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new GetAllTraineeCoursesDTO
                {
                    CourseName = reader.GetString(reader.GetOrdinal("CourseTitle")),
                    TrainerName = reader.GetString(reader.GetOrdinal("TrainerName")),
                    AttendancePercentage = reader.GetDouble(reader.GetOrdinal("AttendancePercentage")),
                    EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate"))
                });
            }

            return result;

        }

        public async Task<List<GetAllTraineesEnrolledInACourseDTO>> GetAllTraineesEnrolledInACourseUsingSP(int CourseId)
        {
            var result = new List<GetAllTraineesEnrolledInACourseDTO>();

            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllTraineesEnrolledInCourse", connection);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@CourseId", SqlDbType.Int)
                .Value = CourseId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                result.Add(new GetAllTraineesEnrolledInACourseDTO
                {
                    CourseTitle = reader.GetString(reader.GetOrdinal("CourseTitle")),
                    TraineeFullName = reader.GetString(reader.GetOrdinal("TraineeFullName")),
                    AttendancePercentage = reader.GetDouble(reader.GetOrdinal("AttendancePercentage")),
                    EnrollmentDate = reader.GetDateTime(reader.GetOrdinal("EnrollmentDate"))
                });
            }

            return result;
        }

        public async Task<GetCourseDetailsDTO> GetCourseDetailsByIdUsingSP(int id)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetCourseDetails", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@Id", SqlDbType.Int)
                   .Value = id;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new GetCourseDetailsDTO
                {
                    CourseTitle = reader.GetString(reader.GetOrdinal("Title")),
                    Description = reader.GetString(reader.GetOrdinal("Description")),
                    Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                    CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                    TrainerName = reader.GetString(reader.GetOrdinal("TrainerName")),
                    Capacity = reader.GetInt32(reader.GetOrdinal("Capacity")),
                    TeachingSubject = reader.GetString(reader.GetOrdinal("TeachingSubject"))
                };
            }

            var result = await _context.getCourseDetailsDTO
                .FromSqlInterpolated($"EXEC SP_GetCourseDetails {id}")
                .ToListAsync();

            return result.SingleOrDefault() ?? new GetCourseDetailsDTO();
        }

        public async Task<bool> SetCourseCpacityUsingSP(int Capacity, int Id)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_SetCourseCapacity", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Capacity", SqlDbType.Int)
            .Value = Capacity;
            command.Parameters.Add("@Id", SqlDbType.Int)
            .Value = Id;

            await connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;



        }

        public async Task<bool> UpdateCourseUsingSP(int Id, Course course)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_SetCourseCapacity", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Id", SqlDbType.Int)
            .Value = course.Id;
            command.Parameters.Add("@Title", SqlDbType.NVarChar)
            .Value = course.Title;

            command.Parameters.Add("@Description", SqlDbType.NVarChar)
            .Value = course.Description;
            command.Parameters.Add("@Price", SqlDbType.Decimal)
            .Value = course.Price;
            command.Parameters.Add("@Capacity", SqlDbType.Int)
            .Value = course.Capacity;

            await connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;

        }
    }
}
