using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GovBE.Models;

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
        public async Task<ActionResult<IEnumerable<District>>> GetDistricts()
        {
          if (_context.Districts == null)
          {
              return NotFound();
          }
            return await _context.Districts.ToListAsync();
        }

        /// <summary>
        ///    Lấy thông tin quận theo id
        /// </summary>
        /// <param name="id">id quận cần tìm kiếm</param>
        /// <returns></returns>
        // GET: api/Districts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<District>> GetDistrict(int id)
        {
          if (_context.Districts == null)
          {
              return NotFound();
          }
            var district = await _context.Districts.FindAsync(id);

            if (district == null)
            {
                return NotFound();
            }

            return district;
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
        public async Task<IActionResult> PutDistrict(int id, District district)
        {
            if (id != district.DistrictId)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        /// <summary>
        /// Thêm 1 quận mới
        /// </summary>
        /// <param name="district">Thông tin quận cần thêm mới</param>
        /// <returns></returns>
        // POST: api/Districts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<District>> PostDistrict(District district)
        {
          if (_context.Districts == null)
          {
              return Problem("Entity set 'GovBE_DatabaseContext.Districts'  is null.");
          }
            _context.Districts.Add(district);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDistrict", new { id = district.DistrictId }, district);
        }
        /// <summary>
        /// Xóa một quận theo id
        /// </summary>
        /// <param name="id">id quận cần xóa</param>
        /// <returns></returns>
        // DELETE: api/Districts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            if (_context.Districts == null)
            {
                return NotFound();
            }
            var district = await _context.Districts.FindAsync(id);
            if (district == null)
            {
                return NotFound();
            }

            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DistrictExists(int id)
        {
            return (_context.Districts?.Any(e => e.DistrictId == id)).GetValueOrDefault();
        }
    }
}
