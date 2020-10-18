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
    public class StageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Stage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stage>>> GetStage()
        {
            return await _context.Stage.ToListAsync();
        }

        // GET: api/Stage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stage>> GetStage(int id)
        {
            var stage = await _context.Stage.FindAsync(id);

            if (stage == null)
            {
                return NotFound();
            }

            return stage;
        }

        // GET: api/Stage/class/5
        [HttpGet("class/{Stageid}")]
        public async Task<ActionResult<IEnumerable<Class>>> GetClassStage(int Stageid)
        {
            var @class = await _context.Class.Where(x => x.StageId == Stageid).ToListAsync<Class>();

            if (@class == null)
            {
                return NotFound();
            }

            return @class;
        }

        // PUT: api/Stage/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStage(int id, Stage stage)
        {
            if (id != stage.Id)
            {
                return BadRequest();
            }

            _context.Entry(stage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StageExists(id))
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

        // POST: api/Stage
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Stage>> PostStage(Stage stage)
        {
            _context.Stage.Add(stage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStage", new { id = stage.Id }, stage);
        }

        // DELETE: api/Stage/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stage>> DeleteStage(int id)
        {
            var stage = await _context.Stage.FindAsync(id);
            if (stage == null)
            {
                return NotFound();
            }

            _context.Stage.Remove(stage);
            await _context.SaveChangesAsync();

            return stage;
        }

        private bool StageExists(int id)
        {
            return _context.Stage.Any(e => e.Id == id);
        }
    }
}
