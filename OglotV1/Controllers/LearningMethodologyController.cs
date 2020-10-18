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
    public class LearningMethodologyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LearningMethodologyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LearningMethodology
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LearningMethodology>>> GetLearningMethodology()
        {
            return await _context.LearningMethodology.ToListAsync();
        }

        // GET: api/LearningMethodology/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LearningMethodology>> GetLearningMethodology(int id)
        {
            var learningMethodology = await _context.LearningMethodology.FindAsync(id);

            if (learningMethodology == null)
            {
                return NotFound();
            }

            return learningMethodology;
        }

        // PUT: api/LearningMethodology/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLearningMethodology(int id, LearningMethodology learningMethodology)
        {
            if (id != learningMethodology.Id)
            {
                return BadRequest();
            }

            _context.Entry(learningMethodology).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LearningMethodologyExists(id))
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

        // POST: api/LearningMethodology
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LearningMethodology>> PostLearningMethodology(LearningMethodology learningMethodology)
        {
            _context.LearningMethodology.Add(learningMethodology);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLearningMethodology", new { id = learningMethodology.Id }, learningMethodology);
        }

        // DELETE: api/LearningMethodology/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LearningMethodology>> DeleteLearningMethodology(int id)
        {
            var learningMethodology = await _context.LearningMethodology.FindAsync(id);
            if (learningMethodology == null)
            {
                return NotFound();
            }

            _context.LearningMethodology.Remove(learningMethodology);
            await _context.SaveChangesAsync();

            return learningMethodology;
        }

        private bool LearningMethodologyExists(int id)
        {
            return _context.LearningMethodology.Any(e => e.Id == id);
        }
    }
}
