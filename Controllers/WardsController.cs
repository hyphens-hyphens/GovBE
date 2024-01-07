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
    public class WardsController : ControllerBase
    {
        private readonly GovBE_DatabaseContext _context;

        public WardsController(GovBE_DatabaseContext context)
        {
            _context = context;
        }
        /// <summary>
        ///  Lấy danh sách các phường
        /// </summary>
        /// <returns></returns>
        // GET: api/Wards
        [HttpGet]
        public async Task<BaseResponse<List<Ward>>> GetWards()
        {
            if (_context.Adslocations == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Ads not found"
                };
            }
            var list = await _context.Wards.ToListAsync();
            return new BaseResponse<List<Ward>>()
            {
                Data = list,
                ErrorMessage = string.Empty,
                IsError = false,
                Status = 200
            };
        }
        /// <summary>
        ///   Lấy thông tin phường theo id
        /// </summary>
        /// <param name="id">id phường cần tìm</param>
        /// <returns></returns>
        // GET: api/Wards/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<Ward>> GetWard(int id)
        {
            if (_context.Wards == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Wards not found"
                };
            }
            var ward = await _context.Wards.FindAsync(id);

            if (ward == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Ward not found"
                };
            }

            return new BaseResponse<Ward>
            {
                ErrorMessage = string.Empty,
                Status = 200,
                Data = ward,
                IsError = false
            };
        }
        /// <summary>
        ///    Update thông tin phường theo id
        /// </summary>
        /// <param name="id">id phường cần thay đổi</param>
        /// <param name="ward">Thông tin phường cần thay đổi</param>
        /// <returns></returns>
        // PUT: api/Wards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> PutWard(int id, Ward ward)
        {
            if (id != ward.WardId)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Update failed"
                };
            }

            _context.Entry(ward).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WardExists(id))
                {
                    return new()
                    {
                        IsError = true,
                        Data = new(),
                        ErrorMessage = "Ward not found"
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
        /// Thêm 1 phường mới
        /// </summary>
        /// <param name="ward">Thông tin phường cần thêm mới</param>
        /// <returns></returns>
        // POST: api/Wards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BaseResponse<bool>> PostWard(Ward ward)
        {
            if (_context.Wards == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Entity set 'pplthd_daContext.Ward'  is null."
                };
            }
            _context.Wards.Add(ward);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }
        /// <summary>
        /// Xóa một phường theo id
        /// </summary>
        /// <param name="id">id phường cần xóa</param>
        /// <returns></returns>
        // DELETE: api/Wards/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteWard(int id)
        {
            if (_context.Wards == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Wards context not found."
                };
            }
            var ward = await _context.Wards.FindAsync(id);
            if (ward == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Ward not found."
                };
            }

            _context.Wards.Remove(ward);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        private bool WardExists(int id)
        {
            return (_context.Wards?.Any(e => e.WardId == id)).GetValueOrDefault();
        }
    }
}
