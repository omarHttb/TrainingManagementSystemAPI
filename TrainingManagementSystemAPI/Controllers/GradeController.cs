using Application.DTOS.GradesDTOS;
using Application.ServiceInterfaces;
using Application.Services;
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

        [HttpPut]
        public async Task<IActionResult> UpdateTraineeGrade(decimal TraineeNewGrade, int Id)
        {
            var result = await _GradeService.UpdateTraineeGradeUsingSp(TraineeNewGrade, Id);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> AddTraineeGrade(AddTraineeGradeDTO addTraineeGradeDTO)
        {
            var result = await _GradeService.AddTraineeGradeUsingSp(addTraineeGradeDTO);

            return Ok(result);
        }

        [HttpGet("averageGrade/{courseId:int}")]
        public async Task<IActionResult> GetGradeAverageForCourse(int courseId)
        {
            var result = await _GradeService.GetAverageGradeForCourseUsingSp(courseId);

            return Ok(result);
        }

  
    }
}
