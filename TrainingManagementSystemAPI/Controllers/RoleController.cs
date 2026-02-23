using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase 
    {
        private readonly IRoleService _RoleService;

         public RoleController(IRoleService RoleService)
         {

            _RoleService = RoleService;
         }    
    }
}
