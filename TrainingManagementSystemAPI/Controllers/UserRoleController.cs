using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase 
    {
        private readonly IUserRoleService _UserRoleService;


        public UserRoleController(IUserRoleService UserRoleService)
        {

            _UserRoleService = UserRoleService;
        }   
    }
}
