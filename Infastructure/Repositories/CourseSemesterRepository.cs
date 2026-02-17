using Application.Data.Models;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    public class CourseSemesterRepository : BaseRepository<CourseSemester>, ICourseSemesterRepository
    {

        public CourseSemesterRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        
    }
}
