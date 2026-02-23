using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase 
    {
        private readonly IEnrollmentService _EnrollmentService


         public EnrollmentController(IEnrollmentService EnrollmentService)
         {
        
                    _EnrollmentService = EnrollmentService;
        
         }    
    }
}
