using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _LessonService;


        public LessonController(ILessonService LessonService)
        {

            _LessonService = LessonService;
        }

        [HttpGet("lessons")]
        public async Task<IActionResult> GetAllLessons(int courseId)
        {
            var result = await _LessonService.GetAllLessonsByCourseId(courseId);

            return Ok(result);
        }

        [HttpGet("lessonsAttended")]
        public async Task<IActionResult> GetAttendedLessonsEnrollmentId(int EnrollmentId)
        {
            var result = await _LessonService.GetAllLessonsUserAttended(EnrollmentId);
            return Ok(result);
        }
    }
}
