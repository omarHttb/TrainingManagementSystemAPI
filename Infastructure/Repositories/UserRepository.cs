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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            {
            }
        }

    }
}

