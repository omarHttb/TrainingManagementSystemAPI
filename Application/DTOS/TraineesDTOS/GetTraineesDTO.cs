using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.TraineesDTOS
{
    public class GetTraineesDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime? JoinDate { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
