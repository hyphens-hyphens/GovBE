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
    public class ReportWarningsController : ControllerBase
    {
        private readonly GovBE_DatabaseContext _context;

        public ReportWarningsController(GovBE_DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/ReportWarnings
        [HttpGet]
        public async Task<BaseResponse<List<Reportwarning>>> GetReportwarnings()
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }
            var list = await _context.Reportwarnings.ToListAsync();
            return new BaseResponse<List<Reportwarning>>()
            {
                Data = list,
                ErrorMessage = string.Empty,
                IsError = false,
                Status = 200
            };
        }

        // GET: api/ReportWarnings/5
        [HttpGet("{id}")]
        public async Task<BaseResponse<Reportwarning>> GetReportwarning(int id)
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }
            var reportwarning = await _context.Reportwarnings.FindAsync(id);

            if (reportwarning == null)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Report warning not found"
                };
            }

            return new BaseResponse<Reportwarning>
            {
                ErrorMessage = string.Empty,
                Status = 200,
                Data = reportwarning,
                IsError = false
            };
        }

        // PUT: api/ReportWarnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> PutReportwarning(int id, Reportwarning reportwarning)
        {
            if (id != reportwarning.ReportWarningId)
            {
                return new()
                {
                    IsError = true,
                    Data = new(),
                    ErrorMessage = "Update failed"
                };
            }

            _context.Entry(reportwarning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReportwarningExists(id))
                {
                    return new()
                    {
                        IsError = true,
                        Data = new(),
                        ErrorMessage = "Report warning not found"
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

        // POST: api/ReportWarnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<BaseResponse<Reportwarning>> PostReportwarning(Reportwarning reportwarning)
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Entity set 'pplthd_daContext.Reportwarnings'  is null."
                };
            }
            _context.Reportwarnings.Add(reportwarning);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        // DELETE: api/ReportWarnings/5
        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> DeleteReportwarning(int id)
        {
            if (_context.Reportwarnings == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Report warning context not found."
                };
            }
            var reportwarning = await _context.Reportwarnings.FindAsync(id);
            if (reportwarning == null)
            {
                return new()
                {
                    IsError = true,
                    ErrorMessage = "Report warning not found."
                };
            }

            _context.Reportwarnings.Remove(reportwarning);
            await _context.SaveChangesAsync();

            return new()
            {
                IsError = false
            };
        }

        private bool ReportwarningExists(int id)
        {
            return (_context.Reportwarnings?.Any(e => e.ReportWarningId == id)).GetValueOrDefault();
        }
    }
}
