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
    public class QuestionTargetController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionTargetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/QuestionTarget
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionTarget>>> GetQuestionTarget()
        {
            return await _context.QuestionTarget.ToListAsync();
        }

        // GET: api/QuestionTarget/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionTarget>> GetQuestionTarget(int id)
        {
            var questionTarget = await _context.QuestionTarget.FindAsync(id);

            if (questionTarget == null)
            {
                return NotFound();
            }

            return questionTarget;
        }

        // PUT: api/QuestionTarget/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestionTarget(int id, QuestionTarget questionTarget)
        {
            if (id != questionTarget.Id)
            {
                return BadRequest();
            }

            _context.Entry(questionTarget).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionTargetExists(id))
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

        // POST: api/QuestionTarget
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QuestionTarget>> PostQuestionTarget(QuestionTarget questionTarget)
        {
            _context.QuestionTarget.Add(questionTarget);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuestionTarget", new { id = questionTarget.Id }, questionTarget);
        }

        // DELETE: api/QuestionTarget/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuestionTarget>> DeleteQuestionTarget(int id)
        {
            var questionTarget = await _context.QuestionTarget.FindAsync(id);
            if (questionTarget == null)
            {
                return NotFound();
            }

            _context.QuestionTarget.Remove(questionTarget);
            await _context.SaveChangesAsync();

            return questionTarget;
        }

        private bool QuestionTargetExists(int id)
        {
            return _context.QuestionTarget.Any(e => e.Id == id);
        }
    }
}
