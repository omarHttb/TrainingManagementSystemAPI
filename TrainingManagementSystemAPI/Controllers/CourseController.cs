using Application.DTOS;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        
        [HttpPost("assigntrainer/{trainerId:int}/tocourse/{courseId:int}")]
        public async Task<IActionResult> AssignTrainerToCourse(int courseId, int trainerId)
        {
            var result = await _courseService.AssignTrainerToCourseUsingSP(courseId, trainerId);
            return Ok(result);
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDTO createCourseDTO)
        {
            var result = await _courseService.CreateCourseUsingSP(createCourseDTO);
            return Ok(result);
        }

        
        [HttpDelete("{courseId:int}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var result = await _courseService.DeleteCourseUsingSP(courseId);
            return Ok(result);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllCoursesDetails()
        {
            var result = await _courseService.GetAllCourseDetailsUsingSP();
            return Ok(result);
        }

        
        [HttpGet("{courseId:int}")]
        public async Task<IActionResult> GetCourseDetailsById(int courseId)
        {
            var result = await _courseService.GetCourseDetailsByIdUsingSP(courseId);
            return Ok(result);
        }

        
        [HttpPut("{courseId:int}/capacity")]
        public async Task<IActionResult> SetCourseCapacity(int courseId, [FromBody] int capacity)
        {
            var result = await _courseService.SetCourseCpacityUsingSP(capacity, courseId);
            return Ok(result);
        }

        
        [HttpPut("{courseId:int}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] UpdateCourseDTO updateCourseDTO)
        {
            var result = await _courseService.UpdateCourseUsingSP(courseId, updateCourseDTO);
            return Ok(result);
        }
    }
}