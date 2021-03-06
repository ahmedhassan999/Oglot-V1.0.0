﻿using System;
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
    public class SemesterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SemesterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Semester
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Semester>>> GetSemester()
        {
            return await _context.Semester.ToListAsync();
        }

        // GET: api/Semester/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Semester>> GetSemester(int id)
        {
            var semester = await _context.Semester.FindAsync(id);

            if (semester == null)
            {
                return NotFound();
            }

            return semester;
        }

        // GET: api/Semester/subject/5
        [HttpGet("subject/{semesterid}")]
        public async Task<ActionResult<IEnumerable<Subject>>> GetClassStage(int semesterid)
        {
            var @subjects = await _context.Subject.Where(x => x.SemesterId == semesterid).ToListAsync<Subject>();

            if (@subjects == null)
            {
                return NotFound();
            }

            return @subjects;
        }

        // PUT: api/Semester/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSemester(int id, Semester semester)
        {
            if (id != semester.Id)
            {
                return BadRequest();
            }

            _context.Entry(semester).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SemesterExists(id))
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

        // POST: api/Semester
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Semester>> PostSemester(Semester semester)
        {
            _context.Semester.Add(semester);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSemester", new { id = semester.Id }, semester);
        }

        // DELETE: api/Semester/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Semester>> DeleteSemester(int id)
        {
            var semester = await _context.Semester.FindAsync(id);
            if (semester == null)
            {
                return NotFound();
            }

            _context.Semester.Remove(semester);
            await _context.SaveChangesAsync();

            return semester;
        }

        private bool SemesterExists(int id)
        {
            return _context.Semester.Any(e => e.Id == id);
        }
    }
}
