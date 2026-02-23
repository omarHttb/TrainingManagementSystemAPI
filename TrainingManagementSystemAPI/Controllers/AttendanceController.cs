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
    }
}
