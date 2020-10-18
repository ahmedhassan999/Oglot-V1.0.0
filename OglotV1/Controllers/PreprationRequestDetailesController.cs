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
    public class PreprationRequestDetailesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PreprationRequestDetailesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PreprationRequestDetailes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreprationRequestDetailes>>> GetPreprationRequestDetailes()
        {
            return await _context.PreprationRequestDetailes.ToListAsync();
        }

        // GET: api/PreprationRequestDetailes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreprationRequestDetailes>> GetPreprationRequestDetailes(long id)
        {
            var preprationRequestDetailes = await _context.PreprationRequestDetailes.FindAsync(id);

            if (preprationRequestDetailes == null)
            {
                return NotFound();
            }

            return preprationRequestDetailes;
        }

        // PUT: api/PreprationRequestDetailes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreprationRequestDetailes(long id, PreprationRequestDetailes preprationRequestDetailes)
        {
            if (id != preprationRequestDetailes.Id)
            {
                return BadRequest();
            }

            _context.Entry(preprationRequestDetailes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreprationRequestDetailesExists(id))
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

        // POST: api/PreprationRequestDetailes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreprationRequestDetailes>> PostPreprationRequestDetailes(PreprationRequestDetailes preprationRequestDetailes)
        {
            _context.PreprationRequestDetailes.Add(preprationRequestDetailes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreprationRequestDetailes", new { id = preprationRequestDetailes.Id }, preprationRequestDetailes);
        }

        // DELETE: api/PreprationRequestDetailes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreprationRequestDetailes>> DeletePreprationRequestDetailes(long id)
        {
            var preprationRequestDetailes = await _context.PreprationRequestDetailes.FindAsync(id);
            if (preprationRequestDetailes == null)
            {
                return NotFound();
            }

            _context.PreprationRequestDetailes.Remove(preprationRequestDetailes);
            await _context.SaveChangesAsync();

            return preprationRequestDetailes;
        }

        private bool PreprationRequestDetailesExists(long id)
        {
            return _context.PreprationRequestDetailes.Any(e => e.Id == id);
        }
    }
}
