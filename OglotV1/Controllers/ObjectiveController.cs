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
    public class ObjectiveController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ObjectiveController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Objective
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Objective>>> GetObjective()
        {
            return await _context.Objective.ToListAsync();
        }

        // GET: api/Objective/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Objective>> GetObjective(int id)
        {
            var objective = await _context.Objective.FindAsync(id);

            if (objective == null)
            {
                return NotFound();
            }

            return objective;
        }

        // PUT: api/Objective/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObjective(int id, Objective objective)
        {
            if (id != objective.Id)
            {
                return BadRequest();
            }

            _context.Entry(objective).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectiveExists(id))
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

        // POST: api/Objective
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Objective>> PostObjective(Objective objective)
        {
            _context.Objective.Add(objective);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObjective", new { id = objective.Id }, objective);
        }

        // DELETE: api/Objective/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Objective>> DeleteObjective(int id)
        {
            var objective = await _context.Objective.FindAsync(id);
            if (objective == null)
            {
                return NotFound();
            }

            _context.Objective.Remove(objective);
            await _context.SaveChangesAsync();

            return objective;
        }

        private bool ObjectiveExists(int id)
        {
            return _context.Objective.Any(e => e.Id == id);
        }
    }
}
