using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class GetAllTraineesEnrolledInACourseDTO
    {

        public string CourseTitle { get; set; } = string.Empty;

        public string TraineeFullName { get; set; } = string.Empty;

        public DateTime EnrollmentDate { get; set; } 

        public double AttendancePercentage { get; set; }
    }
}
