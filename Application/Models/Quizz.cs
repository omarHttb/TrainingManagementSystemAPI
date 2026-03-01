using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Quizz
    {
            
        public int Id { get; set; }

        public int LessonId { get; set; }

        public short GradeEarned { get; set; }

        public short MaxGrade { get; set; }

        public DateTime QuizzDate { get; set; }

        public virtual Lesson Lesson { get; set; } = null!;

    }
}
