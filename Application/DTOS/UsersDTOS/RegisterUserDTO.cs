using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.UsersDTOS
{
    public class RegisterUserDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }

        public DateTime UserCreationDate { get; set; } = DateTime.Now;

        public char Gender { get; set; } 
    }
}
