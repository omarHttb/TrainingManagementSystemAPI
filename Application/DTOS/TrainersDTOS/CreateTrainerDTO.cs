using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.TrainersDTOS
{
    public class CreateTrainerDTO
    {
        public int UserId { get; set; }

        public string TeachingSubject { get; set; } = null!;

        public bool IsActive { get; set; }  

        public string Bio { get; set; } = null!;

        public string Headline { get; set; } = null!;

        public short ExperienceYears { get; set; }

        public DateTime? JoinDate { get; set; }

    }
}
