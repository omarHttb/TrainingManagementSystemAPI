using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.AttendanceDTOS
{
    public class TraineeAttendanceReportDTO
    {
        public string CourseTitle { get; set; }     = string.Empty;
        public string TrainerFullName { get; set; } = string.Empty;
        public string TraineeFullName { get; set; } = string.Empty;
        public string CourseSemester { get; set; } = string.Empty;
        public DateOnly AttendanceDate {  get; set; }
        public bool DidAttend { get; set; }
    }
}
