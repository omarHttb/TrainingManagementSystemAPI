using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.LessonsDTOS
{
    public class UpdateLessonDTO
    {
        public int Id { get; set; }
        public string LessonName { get; set; } = string.Empty;
        public string LessonDescription { get; set; }   = string.Empty;
    }
}
