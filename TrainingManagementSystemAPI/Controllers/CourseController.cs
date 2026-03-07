using Application.DTOS;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Roles = "Admin")]
        [HttpPost("assign/{trainerId:int}/course/{courseId:int}")]
        public async Task<IActionResult> AssignTrainerToCourse(int courseId, int trainerId)
        {
            var result = await _courseService.AssignTrainerToCourseUsingSP(courseId, trainerId);
            return Ok(result);
        }



        [Authorize(Roles = "Trainer")]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseDTO createCourseDTO)
        {
            var result = await _courseService.CreateCourseUsingSP(createCourseDTO);
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpDelete("{courseId:int}")]
        public async Task<IActionResult> DeleteCourse(int courseId)
        {
            var result = await _courseService.DeleteCourseUsingSP(courseId);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("details")]
        public async Task<IActionResult> GetAllCoursesDetails()
        {
            var result = await _courseService.GetAllCourseDetailsUsingSP();
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var result = await _courseService.GetAllCoursesUsingSP();
            return Ok(result);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("{courseId:int}")]
        public async Task<IActionResult> GetCourseDetailsById(int courseId)
        {
            var result = await _courseService.GetCourseDetailsByIdUsingSP(courseId);
            return Ok(result);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPut("{courseId:int}/capacity")]
        public async Task<IActionResult> SetCourseCapacity(int courseId, [FromBody] int capacity)
        {
            var result = await _courseService.SetCourseCpacityUsingSP(capacity, courseId);
            return Ok(result);
        }

        [Authorize(Roles = "Trainer")]
        [HttpPut("{courseId:int}")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] UpdateCourseDTO updateCourseDTO)
        {
            var result = await _courseService.UpdateCourseUsingSP(courseId, updateCourseDTO);
            return Ok(result);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{courseId:int}/enrolledtrainees")]
        public async Task<IActionResult> GetAllTraineesEnrolledInACourse(int courseId)
        {
            var result = await _courseService.GetAllTraineesEnrolledInACourseUsingSP(courseId);
            return Ok(result);
        }
        [Authorize(Roles = "Admin")]
        [HttpPatch("verify")]
        public async Task<IActionResult> VerifyCourse(int courseId, int verifiedById, bool isVerfie)
        {
            var result = await _courseService.SetVerifyCourseUsingSP(courseId, isVerfie, verifiedById);

            return Ok("Verfiy operation completed");
        }

        [Authorize(Roles = "Trainer")]
        [HttpPatch("activate")]
        public async Task<IActionResult> ActivateCourse(int courseId, bool isActive)
        {
            var result = await _courseService.SetActivateCourseUsingSP(courseId, isActive);

            return Ok("Activation operation completed");
        }
        [Authorize(Roles = "Trainer, Admin, Trainee")]
        [HttpGet("activeandverified")]
        public async Task<IActionResult> GetAllActiveAndVerifiedCourses()
        {
            var result = await _courseService.GetAllVerifiedAndActiveCoursesUsingSP();
            return Ok(result);
        }
    }
}