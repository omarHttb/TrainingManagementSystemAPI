using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class CreateEnrollmentDTO
    {
        public int CourseSemesterId { get; set; }

        public int TraineeId { get; set; }

        public DateTime? EnrollmentDate { get; set; } = DateTime.Now;
    }
}
