using Microsoft.AspNetCore.Mvc;
using UserLoginBE.Models;
using UserLoginBE.Services;

namespace UserLoginBE.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
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

        [HttpPost("login")]
        public async Task<IActionResult> Authenticate([FromBody] UserRegistrationDto user)
        {
            if (!await _authenticationService.ValidateUser(user))
                return Unauthorized();

            return Ok(new
            {
                Token = await _authenticationService.CreateToken()
            });
        }
    }
}
