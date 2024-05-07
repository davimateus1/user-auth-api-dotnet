using UsersAuthAPI.Services;
using UsersAuthAPI.Data.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace UsersAuthAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService registerService)
        {
            _userService = registerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(CreateUserDTO createUserDTO)
        {
            await _userService.Register(createUserDTO);
            
            return Ok("User successfully registered!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDTO loginUserDTO)
        {
            var token = await _userService.Login(loginUserDTO);

            return Ok(token);
        }
    }
}
