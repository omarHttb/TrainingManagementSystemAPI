using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class GetAttendanceReportPerCourse
    {
        public int EnrollmentID { get; set; }   

        public bool DidAttend { get; set; }

        public string LessonName { get; set; } = string.Empty;

        public string CourseTitle { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; }

        public DateOnly AttendanceDate { get; set; }

    }
}
