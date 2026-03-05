using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public RoleService(IUnitOfWork unitOfWork) 
        {
            _UnitOfWork = unitOfWork;
        }

        public async Task<bool> AssignRoleToUserUsingSP(int userId, int roleId)
        {
          var result = await   _UnitOfWork.RoleRepository.AssignRoleToUserUsingSP(userId, roleId);



            return result;
        }
    }
}
