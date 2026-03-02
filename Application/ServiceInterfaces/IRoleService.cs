
namespace Application.ServiceInterfaces
{
    public interface IRoleService
    {
        Task<bool> AssignRoleToUser(int userId, int roleId);

    }
}
