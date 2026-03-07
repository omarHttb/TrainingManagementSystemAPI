using Application.DTOS.LessonsDTOS;
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
            var result = await _LessonService.GetAllDetailedLessonsByCourseIdUsingSP(courseId);

            return Ok(result);
        }

        [HttpGet("attended")]
        public async Task<IActionResult> GetAttendedLessonsEnrollmentId(int EnrollmentId)
        {
            var result = await _LessonService.GetAllLessonsUserAttendedUsingSP(EnrollmentId);
            return Ok(result);
        }


        [HttpPatch("activatelesson")]
        public async Task<IActionResult> ActivateLesson(int lessonId, bool isActive)
        {
            var result = await _LessonService.SetActivateLessonUsingSP(lessonId, isActive);

            return Ok("Activation change proccess completed");
        }

        [HttpGet("course/{courseId}/enrollment/{enrollmentId}")]
        public async Task<IActionResult> GetAllCourseLessons(int courseId, int enrollmentId)
        {
            var result = await _LessonService.GetAllCourseLessonsUsingSP(courseId, enrollmentId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLesson(CreateLessonDTO lessonDTO)
        {
            var result = await _LessonService.CreateLessonUsingSP(lessonDTO);
            return Ok("Lesson Created Successfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLesson(UpdateLessonDTO updateLessonDTO)
        {
            var result = await _LessonService.UpdateLessonUsingSP(updateLessonDTO);
            return Ok(result);
        }

        [HttpGet("active/course/{courseId}/enrollment/{enrollmentId}")]
        public async Task<IActionResult> GetActiveCourseLessons(int courseId, int enrollmentId)
        {
            var result = await _LessonService.GetAllActiveCourseLessonsUsingSP(courseId, enrollmentId);

            return Ok(result);
        }
    }
}
