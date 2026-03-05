using Application.DTOS.AttendanceDTOS;
using Application.DTOS.AttendancesDTOS;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendenceService _AttendanceService;


        public AttendanceController(IAttendenceService AttendanceService)
        {

            _AttendanceService = AttendanceService;
        }

        [HttpPost("record")]
        public async Task<IActionResult> RecordAttendancePerLessonForTrainee(CreateAttendanceDTO dto)
        {
            var result = await _AttendanceService.RecordAttendancePerLessonUsingSP(dto);

            return Ok(result);
        }

        [HttpGet("percentage/{traineeId}")]
        public async Task<IActionResult> AttendancePercentageForTrainee(int traineeId)
        {
            var result = await _AttendanceService.CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(traineeId);

            return Ok(result);
        }

        [HttpGet("report/{courseId}")]
        public async Task<IActionResult> AttendanceReportForCourse(int courseId)
        {
            var result = await _AttendanceService.GetAttendanceReportForACourseUsingSP(courseId);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateAttendanceStatus(UpdateAttendanceDTO dto)
        {
            var result = await _AttendanceService.UpdateAttendanceUsingSP(dto);
            return Ok(result);
        }
    }
}
