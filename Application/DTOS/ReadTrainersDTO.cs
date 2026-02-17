using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class ReadTrainersDTO
    {
        public int UserId { get; set; }

        public string TeachingSubject { get; set; } = null!;

        public DateTime? JoinDate { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

    }
}
