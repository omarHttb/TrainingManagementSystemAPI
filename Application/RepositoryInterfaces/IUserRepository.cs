using Application.DTOS.UsersDTOS;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {

        Task<bool> RegisterUserUsingSP(User user);

        Task<bool> DoesEmailExist(string email, int? excludePersonId = null);

        Task<LoginDTO> Login(string email, string password);

        Task<List<string>> GetUserRoles(int userId);

    }
}
