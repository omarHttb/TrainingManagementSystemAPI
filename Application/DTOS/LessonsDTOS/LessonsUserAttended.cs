using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.LessonsDTOS
{
    public class LessonsUserAttended
    {
        public int AttendanceId { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string LessonName { get; set; } = string.Empty;

        public string CourseTitle {  get; set; } = string.Empty;

        public int LessonId { get; set; }

        public bool DidAttend { get; set; }

    }
}
