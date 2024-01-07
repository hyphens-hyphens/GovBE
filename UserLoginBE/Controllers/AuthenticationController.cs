using Microsoft.AspNetCore.Mvc;
using UserLoginBE.Models;
using UserLoginBE.Services;

namespace UserLoginBE.Controllers
{
    /// <summary>
    /// Controller cho việc đăng ký, register
    /// </summary>
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticationService"></param>
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="userForRegistration"></param>
        /// <returns></returns>
        [HttpPost("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDto userForRegistration)
        {
            var result = await _authenticationService.RegisterUser(userForRegistration);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <param name="user">Object với các tham số cần thiết để đăng ký</param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserRegistrationDto user)
        {
            var validateUser = await _authenticationService.ValidateUser(user);
            if (!validateUser.IsSuccess)
                return Unauthorized();

            return Ok(new AuthenticateResponse
            {
                Token = await _authenticationService.CreateToken(),
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
            });
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class AuthenticateResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}
