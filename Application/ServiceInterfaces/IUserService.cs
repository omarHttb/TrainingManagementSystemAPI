using Application.DTOS.UsersDTOS;

namespace Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> RegisterNewUser(RegisterUserDTO registerUserDTO);

        Task<LoginDTO> LoginUser(LoginDTO loginDTO);

        Task<List<UsersDTO>> GetUsersByRoles(int RoleId);
    }
}
