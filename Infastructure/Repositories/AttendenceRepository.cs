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
    public class AttendenceRepository : BaseRepository<Attendence>, IAttendenceRepository
    {

        public AttendenceRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        
    }
}
