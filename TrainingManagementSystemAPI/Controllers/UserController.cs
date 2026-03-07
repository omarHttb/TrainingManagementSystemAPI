using Application.DTOS.UsersDTOS;
using Application.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using TrainingManagementSystemAPI.JWT;

namespace TrainingManagementSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly TokenProvider _tokenProvider;

        public UserController(IUserService UserService, TokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
            _UserService = UserService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterNewUser(RegisterUserDTO registerUserDTO)
        {

            var result = await _UserService.RegisterNewUserUsingSP(registerUserDTO);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _UserService.LoginUserUsingSP(loginDTO);

          

            string token = _tokenProvider.create(result);

            return Ok(token);
        }

        [HttpGet("byroles")]
        public async Task<IActionResult> GetUsersByRole(int roleId, int pageNumber, int pageSize)
        {
            var result = await _UserService.GetUsersByRolesUsingSP(roleId, pageNumber, pageSize);

            return Ok(result);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetUsersWithPagination( int pageNumber, int pageSize)
        {
            var result = await _UserService.GetUsersWithPaginationUsingSP(pageNumber, pageSize);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateUser(UpdateUserDTO updateUserDTO)
        {
            var result = await _UserService.UpdateUserUsingSP(updateUserDTO);

            return Ok("User Updated successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = await _UserService.GetAllUsers();

            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAllUsersById(int Id)
        {
            var result = await _UserService.GetUserById(Id);

            return Ok(result);
        }
    }
}
