using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public UserService(IUnitOfWork unitOfWork) 
        {
            _UnitOfWork = unitOfWork;
        }    

     
    }
}
