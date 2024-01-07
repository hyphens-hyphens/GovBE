using GovBE.Models;
using Microsoft.AspNetCore.Identity;
using UserLoginBE.Entities.Models;

namespace UserLoginBE.Configures
{
    public static class Configures
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<UserApp, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 6;
                o.User.RequireUniqueEmail = false;
            })
            .AddEntityFrameworkStores<GovBE_DatabaseContext>()
            .AddDefaultTokenProviders();
        }
    }
}
