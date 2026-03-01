using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.TrainersDTOS
{
    public class TrainerWithDetailsDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string TeachingSubject { get; set; } = string.Empty;

        public DateTime JoinDate { get; set; }

        public string Headline { get; set; } = string.Empty;

        public int yearsOfExperience { get; set; }

        public bool IsVerified { get; set; }

        public bool IsActive { get; set; }  


    }
}
