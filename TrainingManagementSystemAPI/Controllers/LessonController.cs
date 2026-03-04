using Application.ServiceInterfaces;
using Application.Services;
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

        [HttpGet("detailed")]
        public async Task<IActionResult> GetAllLessons(int courseId)
        {
            var result = await _LessonService.GetAllLessonsByCourseIdUsingSP(courseId);

            return Ok(result);
        }

        [HttpGet("lessonsattended")]
        public async Task<IActionResult> GetAttendedLessonsEnrollmentId(int EnrollmentId)
        {
            var result = await _LessonService.GetAllLessonsUserAttendedUsingSP(EnrollmentId);
            return Ok(result);
        }


        [HttpPatch("activatelesson")]
        public async Task<IActionResult> ActivateLesson(int lessonId, bool isActive)
        {
            var result = await _LessonService.SetActivateLessonUsingSP(lessonId, isActive);

            return Ok(result);
        }

        [HttpGet("lessons")]
        public async Task<IActionResult> GetAllCourseLessons(int courseId)
        {
            var result = await _LessonService.GetAllCourseLessonsUsingSP(courseId);

            return Ok(result);
        }


    }
}
