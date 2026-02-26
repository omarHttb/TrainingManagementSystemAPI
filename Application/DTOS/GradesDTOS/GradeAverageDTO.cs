using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.GradesDTOS
{
    public class GradeAverageDTO
    {
        public string CourseTitle { get; set; }

        public string CourseSemester { get; set; }
        public double GradeAverage { get; set; }
    }
}
