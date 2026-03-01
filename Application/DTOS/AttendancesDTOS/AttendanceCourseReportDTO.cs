using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.AttendancesDTOS
{
    public class AttendanceCourseReportDTO
    {
       public int Id { get; set; }

       public string CourseTitle { get; set; } = string.Empty;
        public string TraineeFullName { get; set; } = string.Empty;
        public DateTime EnrollmentDate { get; set; }
         public double AttendancePercentage { get; set; }

        public string TrainerFullName { get; set; } = string.Empty;

        public string TrainerTeachingSubject { get; set; } = string.Empty;  

        public short TrainerExperienceYears { get; set; }

        public string TrainerHeadline { get; set; } = string.Empty;
    }
}
