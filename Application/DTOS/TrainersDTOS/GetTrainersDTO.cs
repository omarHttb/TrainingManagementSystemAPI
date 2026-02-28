using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.TrainersDTOS
{
    public class GetTrainersDTO
    {
        public int UserId { get; set; }

        public string TeachingSubject { get; set; } = null!;

        public DateTime? JoinDate { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

    }
}
