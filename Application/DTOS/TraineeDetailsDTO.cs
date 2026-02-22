using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS
{
    public class TraineeDetailsDTO
    {
        public int Id { get; set; }

        public string FullName { get; set; }  = string.Empty;   

        public string Email { get; set; } = string.Empty ;

        public DateTime JoinDate    { get; set; }
    }
}
