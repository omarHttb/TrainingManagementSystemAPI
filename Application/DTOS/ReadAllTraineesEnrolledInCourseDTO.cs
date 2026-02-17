using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class ReadAllTraineesEnrolledInCourseDTO
    {

        public int Id { get; set; }
        public string CourseTitle { get; set; } = string.Empty;

        public string TrainerFullName { get; set; } = string.Empty;

        public List<string> TraineeFullName { get; set; } = new List<string>();    


    }
}
