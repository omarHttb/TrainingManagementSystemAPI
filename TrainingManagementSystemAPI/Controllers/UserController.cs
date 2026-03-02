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

            var result = await _UserService.RegisterNewUser(registerUserDTO);

            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var result = await _UserService.LoginUser(loginDTO);

            string token = _tokenProvider.create(loginDTO);

            return Ok(token);
        }
    }
}
