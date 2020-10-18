using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OglotV1.Models;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee")]
    public class WritingTimePeriodController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WritingTimePeriodController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WritingTimePeriod
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<WritingTimePeriod>>> GetWritingTimePeriod()
        {
            return await _context.WritingTimePeriod.ToListAsync();
        }

        // GET: api/WritingTimePeriod/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<WritingTimePeriod>> GetWritingTimePeriod(int id)
        {
            var writingTimePeriod = await _context.WritingTimePeriod.FindAsync(id);

            if (writingTimePeriod == null)
            {
                return NotFound();
            }

            return writingTimePeriod;
        }

        // PUT: api/WritingTimePeriod/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWritingTimePeriod(int id, WritingTimePeriod writingTimePeriod)
        {
            if (id != writingTimePeriod.Id)
            {
                return BadRequest();
            }

            _context.Entry(writingTimePeriod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WritingTimePeriodExists(id))
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

        // POST: api/WritingTimePeriod
        [HttpPost]
        public async Task<ActionResult<WritingTimePeriod>> PostWritingTimePeriod(WritingTimePeriod writingTimePeriod)
        {
            _context.WritingTimePeriod.Add(writingTimePeriod);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWritingTimePeriod", new { id = writingTimePeriod.Id }, writingTimePeriod);
        }

        // DELETE: api/WritingTimePeriod/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WritingTimePeriod>> DeleteWritingTimePeriod(int id)
        {
            var writingTimePeriod = await _context.WritingTimePeriod.FindAsync(id);
            if (writingTimePeriod == null)
            {
                return NotFound();
            }

            _context.WritingTimePeriod.Remove(writingTimePeriod);
            await _context.SaveChangesAsync();

            return writingTimePeriod;
        }

        private bool WritingTimePeriodExists(int id)
        {
            return _context.WritingTimePeriod.Any(e => e.Id == id);
        }
    }
}
