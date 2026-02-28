using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.GradesDTOS
{
    public class GradeAverageDTO
    {
        public string CourseTitle { get; set; } = string.Empty;

        public string CourseSemester { get; set; } = string.Empty;
        public double GradeAverage { get; set; }
    }
}
