using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public EnrollmentService(IUnitOfWork unitOfWork) 
        {
            _UnitOfWork = unitOfWork;
        }    

     
    }
}
