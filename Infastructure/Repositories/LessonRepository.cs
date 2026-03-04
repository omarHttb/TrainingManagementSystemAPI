using Application.DTOS.CoursesDTOS;
using Application.DTOS.LessonsDTOS;
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
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    public class LessonRepository : BaseRepository<Lesson>, ILessonRepository
    {
        public LessonRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<AllCourseLessonsDTO>> GetAllCourseLessonsUsingSP(int courseId , int enrollmentId)
        {
            var lessons = new List<AllCourseLessonsDTO>();
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllLessonsForCourse", connection);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@CourseId", SqlDbType.Int)
                    .Value = courseId;
            command.Parameters.Add("@EnrollmentId", SqlDbType.Int)
                 .Value = enrollmentId;

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lessons.Add(new AllCourseLessonsDTO
                {
                    LessonName = reader.GetString(reader.GetOrdinal("LessonName")),
                     DidAttend = reader.IsDBNull(reader.GetOrdinal("DidAttend")) ? false : reader.GetBoolean(reader.GetOrdinal("DidAttend")),
                    Id = reader.GetInt32(reader.GetOrdinal("Id")),

                });
            }

            return lessons;

        }

        public async Task<List<LessonsDTO>> GetAllDetailedLessonsByCourseIdUsingSP(int courseId)
        {
            var lessons = new List<LessonsDTO>();
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllLessonsByCourseId", connection);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@CourseId", SqlDbType.Int)
                    .Value = courseId;


            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync()) 
            {
                lessons.Add(new LessonsDTO
                {
                    LessonName = reader.GetString(reader.GetOrdinal("LessonName")),
                    LessonDescription = reader.GetString(reader.GetOrdinal("LessonDescription")),
                    CourseId = reader.GetInt32(reader.GetOrdinal("CourseId")),
                    lessonId = reader.GetInt32(reader.GetOrdinal("Id")),

                });
            }
       
            return lessons;
        }

        public async Task<List<LessonsUserAttended>> GetAllLessonsUserAttendedUsingSP(int EnrollmentId)
        {
            var lessons = new List<LessonsUserAttended>();
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllAttendedLessonsByUserEnrollmentId", connection);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@EnrollmentId", SqlDbType.Int)
                    .Value = EnrollmentId;


            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                lessons.Add(new LessonsUserAttended
                {
                    LessonName = reader.GetString(reader.GetOrdinal("LessonName")),
                    CourseTitle = reader.GetString(reader.GetOrdinal("CourseTitle")),
                    LessonId = reader.GetInt32(reader.GetOrdinal("LessonId")),
                    AttendanceId = reader.GetInt32(reader.GetOrdinal("AttendanceId")),
                    DidAttend = reader.GetBoolean(reader.GetOrdinal("DidAttend")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                });
            }

            return lessons;
        }

        public async Task<LessonsDTO> GetLessonByIdUsingSp(int lessonId)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetLessonById", connection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@LessonId", SqlDbType.Int)
                   .Value = lessonId;

            await connection.OpenAsync();

            using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                return new LessonsDTO
                {
                    LessonName = reader.GetString(reader.GetOrdinal("LessonName")),
                    LessonDescription = reader.GetString(reader.GetOrdinal("LessonDescription")),
                    lessonId = reader.GetInt32(reader.GetOrdinal("Id")),
                };
            }

            return new LessonsDTO();

        }

        public async Task<bool> SetActivateLessonUsingSP(int lessonId, bool isActive)
        {
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_ActivateLesson", connection);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@Activate", SqlDbType.Bit)
            .Value = isActive;
            command.Parameters.Add("@LessonId", SqlDbType.Int)
            .Value = lessonId;

            await connection.OpenAsync();

            var rowsAffected = await command.ExecuteNonQueryAsync();

            return rowsAffected > 0;
        }
    }
}
