using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class TraineeAttendanceReportDTO
    {
        public string CourseTitle { get; set; }
        public string TrainerFullName { get; set; }
        public string TraineeFullName { get; set; }
        public string CourseSemester { get; set; }
        public DateOnly AttendanceDate {  get; set; }
        public bool DidAttend { get; set; }
    }
}
