using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IRoleRepository : IBaseRepository<Role>
    {
        Task<bool> AssignRoleToUser(int userId, int roleId);
    }
}
