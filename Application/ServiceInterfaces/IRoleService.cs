
namespace Application.ServiceInterfaces
{
    public interface IRoleService
    {
        Task<bool> AssignRoleToUserUsingSP(int userId, int roleId);

    }
}
