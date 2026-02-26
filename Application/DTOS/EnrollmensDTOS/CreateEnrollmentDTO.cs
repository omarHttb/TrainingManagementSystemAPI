using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.EnrollmensDTOS
{
    public class CreateEnrollmentDTO
    {
        public int CourseId { get; set; }

        public int TraineeId { get; set; }

        public DateTime? EnrollmentDate { get; set; } = DateTime.Now;
    }
}
