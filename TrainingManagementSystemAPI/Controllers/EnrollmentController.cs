using Application.DTOS.EnrollmensDTOS;
using Application.ServiceInterfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase 
    {
        private readonly IEnrollmentService _EnrollmentService;


         public EnrollmentController(IEnrollmentService EnrollmentService)
         {
        
                    _EnrollmentService = EnrollmentService;
        
         }

        [HttpPost]
        public async Task<IActionResult> EnrollTraineeIntoACourse(CreateEnrollmentDTO createEnrollmentDTO)
        {
            var result = await _EnrollmentService.EnrollTraineeIntoACourseUsingSp(createEnrollmentDTO);

            return Ok(result);
        }


    }
}
