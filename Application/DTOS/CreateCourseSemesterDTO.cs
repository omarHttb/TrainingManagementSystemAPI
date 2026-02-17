using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class CreateCourseSemesterDTO
    {
        public int CourseId { get; set; }

        public string Semester { get; set; } = null!;

        public int Capacity { get; set; }

        public DateOnly? CourseYear { get; set; }


    }
}
