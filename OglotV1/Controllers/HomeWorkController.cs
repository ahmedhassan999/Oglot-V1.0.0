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
    public class HomeWorkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeWorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HomeWork
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeWork>>> GetHomeWork()
        {
            return await _context.HomeWork.ToListAsync();
        }

        // GET: api/HomeWork/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeWork>> GetHomeWork(int id)
        {
            var homeWork = await _context.HomeWork.FindAsync(id);

            if (homeWork == null)
            {
                return NotFound();
            }

            return homeWork;
        }

        // PUT: api/HomeWork/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomeWork(int id, HomeWork homeWork)
        {
            if (id != homeWork.Id)
            {
                return BadRequest();
            }

            _context.Entry(homeWork).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeWorkExists(id))
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

        // POST: api/HomeWork
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HomeWork>> PostHomeWork(HomeWork homeWork)
        {
            _context.HomeWork.Add(homeWork);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHomeWork", new { id = homeWork.Id }, homeWork);
        }

        // DELETE: api/HomeWork/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HomeWork>> DeleteHomeWork(int id)
        {
            var homeWork = await _context.HomeWork.FindAsync(id);
            if (homeWork == null)
            {
                return NotFound();
            }

            _context.HomeWork.Remove(homeWork);
            await _context.SaveChangesAsync();

            return homeWork;
        }

        private bool HomeWorkExists(int id)
        {
            return _context.HomeWork.Any(e => e.Id == id);
        }
    }
}
