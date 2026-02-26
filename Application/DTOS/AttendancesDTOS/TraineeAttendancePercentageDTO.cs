using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.AttendanceDTOS
{
    public class TraineeAttendancePercentageDTO
    {
        public string TraineeFullName { get; set; } = string.Empty;

        public int TraineeAttendancePercentage { get; set; }

    }
}
