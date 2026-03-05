using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.LessonsDTOS
{
    public class CreateLessonDTO
    {
        public string LessonName { get; set; } = string.Empty;
        public string LessonDescription { get; set; } = string.Empty;

        public int CourseId { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
