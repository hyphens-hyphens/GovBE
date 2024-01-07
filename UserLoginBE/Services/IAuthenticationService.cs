using Microsoft.AspNetCore.Identity;
using UserLoginBE.Models;

namespace UserLoginBE.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userForRegistration);
        Task<ValidateUserResponse> ValidateUser(UserRegistrationDto userForAuth);
        Task<string> CreateToken();
    }
}
