using Application.DTOS.UsersDTOS;

namespace Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> RegisterNewUserUsingSP(RegisterUserDTO registerUserDTO);

        Task<LoggedInUserDTO> LoginUserUsingSP(LoginDTO loginDTO);

        Task<List<UsersDTO>> GetUsersByRolesUsingSP(int RoleId);

        Task<bool> UpdateUserUsingSP(UpdateUserDTO updateUserDTO);

        Task<List<UsersDTO>> GetAllUsers();

        Task<UsersDTO> GetUserById(int id);
    }
}
