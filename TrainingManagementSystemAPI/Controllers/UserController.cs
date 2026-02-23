using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase 
    {
        private readonly IUserService _UserService;

          public UserController(IUserService UserService)
          {

             _UserService = UserService;
          }    
    
    }
}
