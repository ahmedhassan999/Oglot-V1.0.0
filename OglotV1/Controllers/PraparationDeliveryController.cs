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
    public class PraparationDeliveryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PraparationDeliveryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PraparationDelivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PraparationDelivery>>> GetPraparationDelivery()
        {
            return await _context.PraparationDelivery.ToListAsync();
        }

        // GET: api/PraparationDelivery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PraparationDelivery>> GetPraparationDelivery(long id)
        {
            var praparationDelivery = await _context.PraparationDelivery.FindAsync(id);

            if (praparationDelivery == null)
            {
                return NotFound();
            }

            return praparationDelivery;
        }

        // PUT: api/PraparationDelivery/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPraparationDelivery(long id, PraparationDelivery praparationDelivery)
        {
            if (id != praparationDelivery.Id)
            {
                return BadRequest();
            }

            _context.Entry(praparationDelivery).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PraparationDeliveryExists(id))
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

        // POST: api/PraparationDelivery
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PraparationDelivery>> PostPraparationDelivery(PraparationDelivery praparationDelivery)
        {
            _context.PraparationDelivery.Add(praparationDelivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPraparationDelivery", new { id = praparationDelivery.Id }, praparationDelivery);
        }

        // DELETE: api/PraparationDelivery/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PraparationDelivery>> DeletePraparationDelivery(long id)
        {
            var praparationDelivery = await _context.PraparationDelivery.FindAsync(id);
            if (praparationDelivery == null)
            {
                return NotFound();
            }

            _context.PraparationDelivery.Remove(praparationDelivery);
            await _context.SaveChangesAsync();

            return praparationDelivery;
        }

        private bool PraparationDeliveryExists(long id)
        {
            return _context.PraparationDelivery.Any(e => e.Id == id);
        }
    }
}
