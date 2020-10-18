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
    public class WritingDocumentTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public WritingDocumentTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WritingDocumentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WritingDocumentType>>> GetWritingDocumentType()
        {
            return await _context.WritingDocumentType.ToListAsync();
        }

        // GET: api/WritingDocumentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WritingDocumentType>> GetWritingDocumentType(int id)
        {
            var writingDocumentType = await _context.WritingDocumentType.FindAsync(id);

            if (writingDocumentType == null)
            {
                return NotFound();
            }

            return writingDocumentType;
        }

        // PUT: api/WritingDocumentType/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWritingDocumentType(int id, WritingDocumentType writingDocumentType)
        {
            if (id != writingDocumentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(writingDocumentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WritingDocumentTypeExists(id))
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

        // POST: api/WritingDocumentType
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WritingDocumentType>> PostWritingDocumentType(WritingDocumentType writingDocumentType)
        {
            _context.WritingDocumentType.Add(writingDocumentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWritingDocumentType", new { id = writingDocumentType.Id }, writingDocumentType);
        }

        // DELETE: api/WritingDocumentType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WritingDocumentType>> DeleteWritingDocumentType(int id)
        {
            var writingDocumentType = await _context.WritingDocumentType.FindAsync(id);
            if (writingDocumentType == null)
            {
                return NotFound();
            }

            _context.WritingDocumentType.Remove(writingDocumentType);
            await _context.SaveChangesAsync();

            return writingDocumentType;
        }

        private bool WritingDocumentTypeExists(int id)
        {
            return _context.WritingDocumentType.Any(e => e.Id == id);
        }
    }
}
