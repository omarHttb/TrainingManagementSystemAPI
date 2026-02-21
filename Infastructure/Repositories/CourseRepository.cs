using Application.DTOS;
using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                 ($"EXEC SP_AssignTrainerToCourse {Id},{TrainerId}");

            return rows > 0;
        }

        public async Task<bool> CreateCourseUsingSP(Course course)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                ($"EXEC SP_CreateCourse {course.Title},{course.Description},{course.Price},{course.CreationDate},{course.TrainerId},{course.Capacity}");

            return rows > 0;
        }

        public async Task<bool> DeleteCourseUsingSP(int Id)
        {
            var rows = await _context.Database.ExecuteSqlRawAsync("EXEC SP_DeleteCourse @Id",
                        new SqlParameter("@Id", Id));

            return rows > 0;
        }

        public async Task<List<GetCourseDetailsDTO>> GetAllCourseDetailsUsingSP()
        {
            var result = await _context.getCourseDetailsDTO.FromSqlRaw
                ("EXEC SP_GetAllCoursesDetails").ToListAsync();

            return result;

        }

        public Task<GetCourseDetailsDTO> GetCourseDetailsByIdUsingSP(int Id)
        {
            var result = _context.getCourseDetailsDTO.FromSqlInterpolated($"EXEC SP_GetCourseDetails {Id}")
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<bool> SetCourseCpacityUsingSP(int Capacity, int Id)
        {
            var result = await _context.Database.ExecuteSqlInterpolatedAsync($"EXEC SP_SetCourseCapacity ${Id} ${Capacity}");

            return result > 0;
        }
        
        public async Task<bool> UpdateCourseUsingSP(int Id, Course course)
        {
            var rows = await _context.Database.ExecuteSqlInterpolatedAsync
                ($"EXEC SP_UpdateCourse {Id} ,{course.Title},{course.Description},{course.Price},{course.CreationDate},{course.TrainerId},{course.Capacity}");

            return rows > 0;
        }
    }
}
