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
    public class PreparationRequestTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PreparationRequestTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PreparationRequestType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreparationRequestType>>> GetPreparationRequestType()
        {
            return await _context.PreparationRequestType.ToListAsync();
        }

        // GET: api/PreparationRequestType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreparationRequestType>> GetPreparationRequestType(int id)
        {
            var preparationRequestType = await _context.PreparationRequestType.FindAsync(id);

            if (preparationRequestType == null)
            {
                return NotFound();
            }

            return preparationRequestType;
        }

        // PUT: api/PreparationRequestType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreparationRequestType(int id, PreparationRequestType preparationRequestType)
        {
            if (id != preparationRequestType.Id)
            {
                return BadRequest();
            }

            _context.Entry(preparationRequestType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreparationRequestTypeExists(id))
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

        // POST: api/PreparationRequestType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PreparationRequestType>> PostPreparationRequestType(PreparationRequestType preparationRequestType)
        {
            _context.PreparationRequestType.Add(preparationRequestType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreparationRequestType", new { id = preparationRequestType.Id }, preparationRequestType);
        }

        // DELETE: api/PreparationRequestType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreparationRequestType>> DeletePreparationRequestType(int id)
        {
            var preparationRequestType = await _context.PreparationRequestType.FindAsync(id);
            if (preparationRequestType == null)
            {
                return NotFound();
            }

            _context.PreparationRequestType.Remove(preparationRequestType);
            await _context.SaveChangesAsync();

            return preparationRequestType;
        }

        private bool PreparationRequestTypeExists(int id)
        {
            return _context.PreparationRequestType.Any(e => e.Id == id);
        }
    }
}
