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
    public class AdslocationsController : ControllerBase
    {
        private readonly GovBE_DatabaseContext _context;

        public AdslocationsController(GovBE_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Adslocations
        [HttpGet]
        public async Task<BaseResponse<List<Adslocation>>> GetAdslocations()
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
            var list = await _context.Adslocations.ToListAsync();
            return new BaseResponse<List<Adslocation>>()
            {
                Data = list,
                ErrorMessage = string.Empty,
                IsError = false,
                Status = 200
            };
        }

        // GET: api/Adslocations/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<Adslocation>> GetAdslocation(int id)
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
            var adslocation = await _context.Adslocations.FindAsync(id);

            if (adslocation == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Ads not found"
                };
            }

            return new BaseResponse<Adslocation>
            {
                ErrorMessage = string.Empty,
                Status = 200,
                Data = adslocation,
                IsError = false
            };
        }

        // PUT: api/Adslocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> PutAdslocation(int id, Adslocation adslocation)
        {
            if (id != adslocation.AdsLocationId)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Update failed"
                };
            }

            _context.Entry(adslocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdslocationExists(id))
                {
                    return new()
                    {
                        IsError = true,
                        Data = new(),
                        ErrorMessage = "Ads not found"
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

        // POST: api/Adslocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BaseResponse<bool>> PostAdslocation(Adslocation adslocation)
        {
            if (_context.Adslocations == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Entity set 'pplthd_daContext.Adslocations'  is null."
                };
            }
            _context.Adslocations.Add(adslocation);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        // DELETE: api/Adslocations/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteAdslocation(int id)
        {
            if (_context.Adslocations == null)
            {

            }
            var adslocation = await _context.Adslocations.FindAsync(id);
            if (adslocation == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Ads location not found."
                };
            }

            _context.Adslocations.Remove(adslocation);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        private bool AdslocationExists(int id)
        {
            return (_context.Adslocations?.Any(e => e.AdsLocationId == id)).GetValueOrDefault();
        }
    }
}
