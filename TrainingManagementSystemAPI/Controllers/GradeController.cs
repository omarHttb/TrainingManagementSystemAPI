using Application.DTOS.GradesDTOS;
using Application.ServiceInterfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase 
    {
        private readonly IGradeService _GradeService;


         public GradeController(IGradeService GradeService)
         {
        
                    _GradeService = GradeService;
                
         }

        [Authorize(Roles = "Trainer, Trainee")]
        [HttpPut]
        public async Task<IActionResult> UpdateTraineeGrade(decimal TraineeNewGrade, int Id)
        {
            var result = await _GradeService.UpdateTraineeGradeUsingSp(TraineeNewGrade, Id);
            return Ok(result);

        }

        [Authorize(Roles = "Trainer, Trainee")]
        [HttpPost]
        public async Task<IActionResult> AddTraineeGrade(AddTraineeGradeDTO addTraineeGradeDTO)
        {
            var result = await _GradeService.AddTraineeGradeUsingSp(addTraineeGradeDTO);

            return Ok(result);
        }
        [Authorize(Roles = "Trainer")]
        [HttpGet("average/{courseId:int}")]
        public async Task<IActionResult> GetGradeAverageForCourse(int courseId)
        {
            var result = await _GradeService.GetAverageGradeForCourseUsingSp(courseId);

            return Ok("Grade updated Successfully");
        }

  
    }
}
