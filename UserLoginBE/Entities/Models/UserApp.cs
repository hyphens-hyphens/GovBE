using Microsoft.AspNetCore.Identity;

namespace UserLoginBE.Entities.Models
{
    public class UserApp : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
    }
}
