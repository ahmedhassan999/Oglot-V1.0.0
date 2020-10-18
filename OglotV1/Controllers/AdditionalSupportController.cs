using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OglotV1.Models;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdditionalSupportController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdditionalSupportController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AdditionalSupport
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdditionalSupport>>> GetAdditionalSupport()
        {
            return await _context.AdditionalSupport.ToListAsync();
        }

        // GET: api/AdditionalSupport/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdditionalSupport>> GetAdditionalSupport(int id)
        {
            var additionalSupport = await _context.AdditionalSupport.FindAsync(id);

            if (additionalSupport == null)
            {
                return NotFound();
            }

            return additionalSupport;
        }

        // PUT: api/AdditionalSupport/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdditionalSupport(int id, AdditionalSupport additionalSupport)
        {
            if (id != additionalSupport.Id)
            {
                return BadRequest();
            }

            _context.Entry(additionalSupport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdditionalSupportExists(id))
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

        // POST: api/AdditionalSupport
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AdditionalSupport>> PostAdditionalSupport(AdditionalSupport additionalSupport)
        {
            _context.AdditionalSupport.Add(additionalSupport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdditionalSupport", new { id = additionalSupport.Id }, additionalSupport);
        }

        // DELETE: api/AdditionalSupport/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AdditionalSupport>> DeleteAdditionalSupport(int id)
        {
            var additionalSupport = await _context.AdditionalSupport.FindAsync(id);
            if (additionalSupport == null)
            {
                return NotFound();
            }

            _context.AdditionalSupport.Remove(additionalSupport);
            await _context.SaveChangesAsync();

            return additionalSupport;
        }

        private bool AdditionalSupportExists(int id)
        {
            return _context.AdditionalSupport.Any(e => e.Id == id);
        }
    }
}
