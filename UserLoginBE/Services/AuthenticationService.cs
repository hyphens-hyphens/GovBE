using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Resources;
using System.Security.Claims;
using System.Text;
using UserLoginBE.Common;
using UserLoginBE.Entities.Models;
using UserLoginBE.Models;

namespace UserLoginBE.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<UserApp> _userManager;
        private readonly IConfiguration _configuration;

        private UserApp? _user;

        public AuthenticationService(IMapper mapper,
            UserManager<UserApp> userManager, IConfiguration configuration)
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDto userForRegistration)
        {
            var user = _mapper.Map<UserApp>(userForRegistration);

            var roleInValid = userForRegistration.Roles.FirstOrDefault(x => !RoleConstant.ListRoles.Contains(x));

            if (roleInValid != null)
            {
                throw new Exception("Role invalid");
            }

            var result = await _userManager.CreateAsync(user, userForRegistration.Password);

            if (result.Succeeded)
                await _userManager.AddToRolesAsync(user, userForRegistration.Roles);

            return result;
        }

        public async Task<ValidateUserResponse> ValidateUser(UserRegistrationDto userForAuth)
        {
            _user = await _userManager.FindByNameAsync(userForAuth.UserName);

            bool result = (_user != null && await _userManager.CheckPasswordAsync(_user, userForAuth.Password));

            return new()
            {
                FirstName = userForAuth.FirstName,
                IsSuccess = result,
                LastName = userForAuth.LastName,
                Roles = userForAuth.Roles.ToList(),
                Username = userForAuth?.UserName 
            };
        }

        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_configuration.GetSection("SECRET").ToString());
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, _user.UserName)
        };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");

            var tokenOptions = new JwtSecurityToken
            (
                issuer: jwtSettings["validIssuer"],
                audience: jwtSettings["validAudience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(1000),
                signingCredentials: signingCredentials
            );

            return tokenOptions;
        }
    }

    public class ValidateUserResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Roles { get; set; } = new();
        public string? FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; } = string.Empty;
        public string? Username { get; set; } = string.Empty;
    }
}
