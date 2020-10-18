using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OglotV1.Models;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee")]
    public class WritingConversionTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        

        public WritingConversionTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WritingConversionType
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<WritingConversionType>>> GetWritingConversionType()
        {
            return await _context.WritingConversionType.ToListAsync();
        }


       

        // GET: api/WritingConversionType/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<WritingConversionType>> GetWritingConversionType(int id)
        {
            var writingConversionType = await _context.WritingConversionType.FindAsync(id);

            if (writingConversionType == null)
            {
                return NotFound();
            }

            return writingConversionType;
        }

        // PUT: api/WritingConversionType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWritingConversionType(int id, WritingConversionType writingConversionType)
        {
            if (id != writingConversionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(writingConversionType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WritingConversionTypeExists(id))
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

        // POST: api/WritingConversionType
        [HttpPost]
        public async Task<ActionResult<WritingConversionType>> PostWritingConversionType(WritingConversionType writingConversionType)
        {
            _context.WritingConversionType.Add(writingConversionType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWritingConversionType", new { id = writingConversionType.Id }, writingConversionType);
        }

        // DELETE: api/WritingConversionType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WritingConversionType>> DeleteWritingConversionType(int id)
        {
            var writingConversionType = await _context.WritingConversionType.FindAsync(id);
            if (writingConversionType == null)
            {
                return NotFound();
            }

            _context.WritingConversionType.Remove(writingConversionType);
            await _context.SaveChangesAsync();

            return writingConversionType;
        }

        private bool WritingConversionTypeExists(int id)
        {
            return _context.WritingConversionType.Any(e => e.Id == id);
        }
    }
}
