using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GovBE.Models;
using GovBE.Commons;

namespace GovBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly GovBE_DatabaseContext _context;

        public DistrictsController(GovBE_DatabaseContext context)
        {
            _context = context;
        }


        /// <summary>
        /// Lấy danh sách các quận
        /// </summary>
        /// <returns></returns>
        // GET: api/Districts
        [HttpGet]
        public async Task<BaseResponse<List<District>>> GetDistricts()
        {
            if (_context.Districts == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Districts not found"
                };
            }
            var list = await _context.Districts.ToListAsync();
            return new BaseResponse<List<District>>()
            {
                Data = list,
                ErrorMessage = string.Empty,
                IsError = false,
                Status = 200
            };
        }

        /// <summary>
        ///    Lấy thông tin quận theo id
        /// </summary>
        /// <param name="id">id quận cần tìm kiếm</param>
        /// <returns></returns>
        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<District>> GetDistrict(int id)
        {
            if (_context.Districts == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Districts not found"
                };
            }
            var distric = await _context.Districts.FindAsync(id);

            if (distric == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Districts not found"
                };
            }

            return new BaseResponse<District>
            {
                ErrorMessage = string.Empty,
                Status = 200,
                Data = distric,
                IsError = false
            };
        }
        /// <summary>
        ///  Chỉnh sửa thông tin quận theo id
        /// </summary>
        /// <param name="id">id quận cần chỉnh sửa</param>
        /// <param name="district">Thông tin quận cần chỉnh sửa</param>
        /// <returns></returns>
        // PUT: api/Districts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> PutDistrict(int id, District district)
        {
            if (id != district.DistrictId)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Update failed"
                };
            }

            _context.Entry(district).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DistrictExists(id))
                {
                    return new()
                    {
                        IsError = true,
                        Data = new(),
                        ErrorMessage = "Districts not found"
                    };
                }
                else
                {
                    throw;
                }
            }

            return new()
            {
                IsError = false,
            };
        }
        /// <summary>
        /// Thêm 1 quận mới
        /// </summary>
        /// <param name="district">Thông tin quận cần thêm mới</param>
        /// <returns></returns>
        // POST: api/Districts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BaseResponse<District>> PostDistrict(District district)
        {
            if (_context.Districts == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Entity set 'pplthd_daContext.Districts'  is null."
                };
            }
            _context.Districts.Add(district);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }
        /// <summary>
        /// Xóa một quận theo id
        /// </summary>
        /// <param name="id">id quận cần xóa</param>
        /// <returns></returns>
        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteDistrict(int id)
        {
            if (_context.Districts == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Districts new context not found."
                };
            }
            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Ads location not found."
                };
            }

            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        private bool DistrictExists(int id)
        {
            return (_context.Districts?.Any(e => e.DistrictId == id)).GetValueOrDefault();
        }
    }
}
