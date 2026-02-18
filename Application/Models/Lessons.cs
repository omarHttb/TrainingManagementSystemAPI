using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Lessons
    {
        public int Id { get; set; }

        public string LessonName { get; set; } = string.Empty;

        public string LessonDescription { get; set;} = string.Empty;

        public int CourseId { get; set; }

        public Course course { get; set; } = null!;

        public ICollection<Attendence> Attendences { get; set; }  = new List<Attendence>(); 
    }
}
