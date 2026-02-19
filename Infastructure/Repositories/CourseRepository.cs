using Application.DTOS;
using Application.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
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

        public Task<bool> AssignTrainerToCourseUsingSP(int Id, int TrainerId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CreateCourseUsingSP(Course course)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCourseUsingSP(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<GetCourseDetailsDTO>> GetAllCourseDetailsUsingSP()
        {
            throw new NotImplementedException();
        }

        public Task<GetCourseDetailsDTO> GetCourseDetailsByIdUsingSP(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetCourseCpacityUsingSP(int Cpacity, int Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCourseUsingSP(int Id, Course course)
        {
            throw new NotImplementedException();
        }
    }
}
