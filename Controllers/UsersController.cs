using GovBE.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserLoginBE.Context;
using UserLoginBE.Entities.Models;

namespace GovBE.Controllers
{
    /// <summary>
    /// Users
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserLoginContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userManager"></param>
        public UsersController(UserLoginContext userManager)
        {
            _context = userManager;

        }

        /// <summary>
        /// Lấy danh sách Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<BaseResponse<List<UserApp>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Users not found"
                };
            }
            var list = await _context.Users.ToListAsync();
            return new BaseResponse<List<UserApp>>()
            {
                Data = list,
                ErrorMessage = string.Empty,
                IsError = false,
                Status = 200
            };
        }
    }
}
