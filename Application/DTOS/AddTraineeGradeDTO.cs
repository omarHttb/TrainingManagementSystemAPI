using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class AddTraineeGradeDTO
    {
        public int EnrollmentId { get; set; }

        public int Grade { get; set; }

        public bool IsPass { get; set; }
    }
}
