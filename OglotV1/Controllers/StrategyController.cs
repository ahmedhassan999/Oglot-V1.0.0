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
    public class StrategyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StrategyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Strategy
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Strategy>>> GetStrategy()
        {
            return await _context.Strategy.ToListAsync();
        }

        // GET: api/Strategy/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Strategy>> GetStrategy(int id)
        {
            var strategy = await _context.Strategy.FindAsync(id);

            if (strategy == null)
            {
                return NotFound();
            }

            return strategy;
        }

        // PUT: api/Strategy/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStrategy(int id, Strategy strategy)
        {
            if (id != strategy.Id)
            {
                return BadRequest();
            }

            _context.Entry(strategy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StrategyExists(id))
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

        // POST: api/Strategy
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Strategy>> PostStrategy(Strategy strategy)
        {
            _context.Strategy.Add(strategy);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStrategy", new { id = strategy.Id }, strategy);
        }

        // DELETE: api/Strategy/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Strategy>> DeleteStrategy(int id)
        {
            var strategy = await _context.Strategy.FindAsync(id);
            if (strategy == null)
            {
                return NotFound();
            }

            _context.Strategy.Remove(strategy);
            await _context.SaveChangesAsync();

            return strategy;
        }

        private bool StrategyExists(int id)
        {
            return _context.Strategy.Any(e => e.Id == id);
        }
    }
}
