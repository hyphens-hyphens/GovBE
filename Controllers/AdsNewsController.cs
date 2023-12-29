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
    public class AdsNewsController : ControllerBase
    {
        private readonly GovBE_DatabaseContext _context;

        public AdsNewsController(GovBE_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/AdsNews
        [HttpGet]
        public async Task<BaseResponse<List<Adsnew>>> GetAdsnews()
        {
            if (_context.Adsnews == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Adsnew not found"
                };
            }
            var list = await _context.Adsnews.ToListAsync();
            return new BaseResponse<List<Adsnew>>()
            {
                Data = list,
                ErrorMessage = string.Empty,
                IsError = false,
                Status = 200
            };
        }

        // GET: api/AdsNews/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<Adsnew>> GetAdsnew(int id)
        {
            if (_context.Adsnews == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Adsnew not found"
                };
            }
            var adsnew = await _context.Adsnews.FindAsync(id);

            if (adsnew == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Adsnew not found"
                };
            }

            return new BaseResponse<Adsnew>
            {
                ErrorMessage = string.Empty,
                Status = 200,
                Data = adsnew,
                IsError = false
            };
        }

        // PUT: api/AdsNews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> PutAdsnew(int id, Adsnew adsnew)
        {
            if (id != adsnew.AdsNewId)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Update failed"
                };
            }

            _context.Entry(adsnew).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdsnewExists(id))
                {
                    return new()
                    {
                        IsError = true,
                        Data = new(),
                        ErrorMessage = "Adsnew not found"
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

        // POST: api/AdsNews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BaseResponse<Adsnew>> PostAdsnew(Adsnew adsnew)
        {
            if (_context.Adsnews == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Entity set 'pplthd_daContext.AdsNews'  is null."
                };
            }
            _context.Adsnews.Add(adsnew);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        // DELETE: api/AdsNews/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteAdsnew(int id)
        {
            if (_context.Adsnews == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Ads new context not found."
                };
            }
            var adsnew = await _context.Adsnews.FindAsync(id);
            if (adsnew == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Ads location not found."
                };
            }

            _context.Adsnews.Remove(adsnew);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        private bool AdsnewExists(int id)
        {
            return (_context.Adsnews?.Any(e => e.AdsNewId == id)).GetValueOrDefault();
        }
    }
}
