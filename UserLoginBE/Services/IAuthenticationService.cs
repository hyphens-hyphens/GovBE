using Microsoft.AspNetCore.Identity;
using UserLoginBE.Models;

namespace UserLoginBE.Services
{
    public interface IAuthenticationService
    {
        Task<IdentityResult> RegisterUser(UserRegistrationDto userForRegistration);
        Task<ValidateUserResponse> ValidateUser(UserRegistrationDto userForAuth);
        Task<string> CreateToken();
        Task<string> ForgotPassword(string userEmail);
        Task<IdentityResult> ResetPassword(string userEmail, string token, string newPassword);
    }
}
