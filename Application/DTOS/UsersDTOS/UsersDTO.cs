using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOS.UsersDTOS
{
    public class UsersDTO
    {
        public int Id { get; set; }

        public string FullName {  get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber {  get; set; } = string.Empty;

        public string Gender {  get; set; } = string.Empty;

        public string ProfilePicture {  get; set; } = string.Empty;

        public int age { get; set; }

    }
}
