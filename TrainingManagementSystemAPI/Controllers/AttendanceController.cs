using Application.DTOS.AttendanceDTOS;
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

        [HttpPost("recordattendance")]
        public async Task<IActionResult> RecordAttendancePerLessonForTrainee(CreateAttendanceDTO dto)
        {
            var result = await _AttendanceService.RecordAttendancePerLessonUsingSP(dto);

            return Ok(result);
        }

        [HttpGet("attendancepercentage/{traineeId}")]
        public async Task<IActionResult> AttendancePercentageForTrainee(int traineeId)
        {
            var result = await _AttendanceService.CalculateAttendancePercentagePerTraineeEnrollmentUsingSP(traineeId);

            return Ok(result);
        }
    }
}
