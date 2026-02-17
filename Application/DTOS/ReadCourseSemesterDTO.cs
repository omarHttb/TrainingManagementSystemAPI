using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class ReadCourseSemesterDTO
    {
        public int Id { get; set; }

        public string CourseTitle { get; set; } = string.Empty;

        public string TrainerFullName { get; set; } = string.Empty;

        public string Semester { get; set; } = null!;

        public int Capacity { get; set; }

        public int StudentsRolledIn { get; set; } = 0;

        public DateTime? CourseYear { get; set;}
        

    }
}
