using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.AttendanceDTOS
{
    public class CreateAttendanceDTO
    {
        public int enrollmentId { get; set; }

        public int LessonId { get; set; }

        public DateTime? AttendanceDate { get; set; } = DateTime.Now;

        public bool DidAttend { get; set; }

       
    }
}
