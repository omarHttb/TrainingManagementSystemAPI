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

        Task<int> LoginUsingSP(string email, string password);

        Task<List<string>> GetUserRolesUsingSP(int userId);

        Task<List<UsersDTO>> GetUsersByRolesUsingSP(int RoleId);

        Task<bool> UpdateUserUsingSP(User user);

    }
}
