using Microsoft.AspNetCore.Mvc;
using MyCaseStudy.Dto;
using MyCaseStudy.Interface;

namespace MyCaseStudy.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST: api/user/register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (await _userRepository.IsEmailExistsAsync(userDto.Email))
                {
                    return Conflict("Email already registered.");
                }

                var result = await _userRepository.RegisterUserAsync(userDto);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred during registration.");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto loginDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var user = await _userRepository.LoginUserAsync(loginDto);
                if (user == null)
                    return Unauthorized("Invalid email or password.");

                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred during login.");
            }
        }
    }
}
