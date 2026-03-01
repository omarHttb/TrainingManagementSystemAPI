using Application.DTOS.UsersDTOS;

namespace Application.ServiceInterfaces
{
    public interface IUserService
    {
        Task<bool> RegisterNewUser(RegisterUserDTO registerUserDTO);
    }
}
