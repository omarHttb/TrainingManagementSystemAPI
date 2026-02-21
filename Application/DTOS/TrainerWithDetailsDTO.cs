using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class TrainerWithDetailsDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string TeachingSubject { get; set; } = string.Empty;

        public DateTime JoinDate { get; set; }
    }
}
