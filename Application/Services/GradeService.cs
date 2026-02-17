using Application.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GradeService : IGradeService
    {
        private readonly IUnitOfWork _UnitOfWork;
        public GradeService(IUnitOfWork unitOfWork) 
        {
            _UnitOfWork = unitOfWork;
        }    

     
    }
}
