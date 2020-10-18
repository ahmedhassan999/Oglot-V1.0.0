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
    public class CustomerContactController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomerContactController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerContact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerContact>>> GetCustomerContact()
        {
            return await _context.CustomerContact.ToListAsync();
        }

        // GET: api/CustomerContact/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerContact>> GetCustomerContact(long id)
        {
            var customerContact = await _context.CustomerContact.FindAsync(id);

            if (customerContact == null)
            {
                return NotFound();
            }

            return customerContact;
        }

        // PUT: api/CustomerContact/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerContact(long id, CustomerContact customerContact)
        {
            if (id != customerContact.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerContact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerContactExists(id))
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

        // POST: api/CustomerContact
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerContact>> PostCustomerContact(CustomerContact customerContact)
        {
            _context.CustomerContact.Add(customerContact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerContact", new { id = customerContact.Id }, customerContact);
        }

        // DELETE: api/CustomerContact/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerContact>> DeleteCustomerContact(long id)
        {
            var customerContact = await _context.CustomerContact.FindAsync(id);
            if (customerContact == null)
            {
                return NotFound();
            }

            _context.CustomerContact.Remove(customerContact);
            await _context.SaveChangesAsync();

            return customerContact;
        }

        private bool CustomerContactExists(long id)
        {
            return _context.CustomerContact.Any(e => e.Id == id);
        }
    }
}
