﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PPLTHD_BE.Models;

namespace PPLTHD_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdslocationsController : ControllerBase
    {
        private readonly pplthd_daContext _context;

        public AdslocationsController(pplthd_daContext context)
        {
            _context = context;
        }

        // GET: api/Adslocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adslocation>>> GetAdslocations()
        {
          if (_context.Adslocations == null)
          {
              return NotFound();
          }
            return await _context.Adslocations.ToListAsync();
        }

        // GET: api/Adslocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Adslocation>> GetAdslocation(int id)
        {
          if (_context.Adslocations == null)
          {
              return NotFound();
          }
            var adslocation = await _context.Adslocations.FindAsync(id);

            if (adslocation == null)
            {
                return NotFound();
            }

            return adslocation;
        }

        // PUT: api/Adslocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdslocation(int id, Adslocation adslocation)
        {
            if (id != adslocation.Id)
            {
                return BadRequest();
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
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Adslocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Adslocation>> PostAdslocation(Adslocation adslocation)
        {
          if (_context.Adslocations == null)
          {
              return Problem("Entity set 'pplthd_daContext.Adslocations'  is null.");
          }
            _context.Adslocations.Add(adslocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdslocation", new { id = adslocation.Id }, adslocation);
        }

        // DELETE: api/Adslocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdslocation(int id)
        {
            if (_context.Adslocations == null)
            {
                return NotFound();
            }
            var adslocation = await _context.Adslocations.FindAsync(id);
            if (adslocation == null)
            {
                return NotFound();
            }

            _context.Adslocations.Remove(adslocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdslocationExists(int id)
        {
            return (_context.Adslocations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
