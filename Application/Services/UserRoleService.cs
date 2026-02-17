using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public UserRoleService(IUnitOfWork unitOfWork) 
        {
            _UnitOfWork = unitOfWork;
        }    

     
    }
}
