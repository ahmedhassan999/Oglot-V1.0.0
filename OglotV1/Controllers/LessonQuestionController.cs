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
    public class LessonQuestionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LessonQuestionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LessonQuestion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonQuestion>>> GetLessonQuestion()
        {
            return await _context.LessonQuestion.ToListAsync();
        }

        // GET: api/LessonQuestion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonQuestion>> GetLessonQuestion(long id)
        {
            var lessonQuestion = await _context.LessonQuestion.FindAsync(id);

            if (lessonQuestion == null)
            {
                return NotFound();
            }

            return lessonQuestion;
        }

        // PUT: api/LessonQuestion/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLessonQuestion(long id, LessonQuestion lessonQuestion)
        {
            if (id != lessonQuestion.Id)
            {
                return BadRequest();
            }

            _context.Entry(lessonQuestion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonQuestionExists(id))
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

        // POST: api/LessonQuestion
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LessonQuestion>> PostLessonQuestion(LessonQuestion lessonQuestion)
        {
            _context.LessonQuestion.Add(lessonQuestion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLessonQuestion", new { id = lessonQuestion.Id }, lessonQuestion);
        }

        // DELETE: api/LessonQuestion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LessonQuestion>> DeleteLessonQuestion(long id)
        {
            var lessonQuestion = await _context.LessonQuestion.FindAsync(id);
            if (lessonQuestion == null)
            {
                return NotFound();
            }

            _context.LessonQuestion.Remove(lessonQuestion);
            await _context.SaveChangesAsync();

            return lessonQuestion;
        }

        private bool LessonQuestionExists(long id)
        {
            return _context.LessonQuestion.Any(e => e.Id == id);
        }
    }
}
