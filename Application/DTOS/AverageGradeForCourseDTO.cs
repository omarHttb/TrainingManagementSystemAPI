using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class AverageGradeForCourseDTO
    {
        public string CourseName { get; set; } = string.Empty;

        public float Grade { get; set; }

        public int TotalGrades { get; set; }
    }
}
