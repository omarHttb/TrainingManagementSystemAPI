using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.LessonsDTOS
{
    public class AllCourseLessonsDTO
    {
        public int Id { get; set; } 

        public string LessonName { get; set; } = string.Empty;

        public bool DidAttend { get; set; }
    }
}
