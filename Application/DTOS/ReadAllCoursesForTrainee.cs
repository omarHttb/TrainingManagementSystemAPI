using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class ReadAllCoursesForTrainee
    {
        public int Id { get; set; }

        public string TraineeFullName { get; set; } = string.Empty;
        public List<string> Courses { get; set; } = new List<string>();

    }
}
