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

        public async Task<List<LessonsDTO>> GetAllLessonsByCourseId(int courseId)
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

        public async Task<List<LessonsUserAttended>> GetAllLessonsUserAttended(int EnrollmentId)
        {
            var lessons = new List<LessonsUserAttended>();
            using var connection = new SqlConnection(_context.Database.GetConnectionString());
            using var command = new SqlCommand("SP_GetAllAttendedLessonsByUserEnrollmentId", connection);

            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@CourseId", SqlDbType.Int)
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
    }
}
