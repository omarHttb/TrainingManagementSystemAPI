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
    public class TrainerRepository : BaseRepository<Trainer>, ITrainerRepository
    {

        public TrainerRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

        
    }
}
