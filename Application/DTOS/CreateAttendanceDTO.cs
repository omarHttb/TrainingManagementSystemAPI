using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class CreateAttendanceDTO
    {
        public int enrollmentId { get; set; }

        public DateOnly? AttendanceDate { get; set; }

        public bool DidAttend { get; set; }
    }
}
