using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OglotV1.Helpers;
using OglotV1.Models;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparationRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PreparationRequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/PreparationRequest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PreparationRequest>>> GetPreparationRequest()
        {
            return await _context.PreparationRequest
                .Include(x => x.Customer)
                .ThenInclude(x => x.CustomerContact)
                .Include(x => x.PreprationRequestDetailes)
                //.ThenInclude(x=>x.Subject)
                //.Include(x=>x.PreparationRequestType)
                .Include(x => x.PraparationDelivery)
                .ToListAsync();
        }

        // GET: api/PreparationRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PreparationRequest>> GetPreparationRequest(long id)
        {
            var preparationRequest = await _context.PreparationRequest.FindAsync(id);
            await _context.PreparationRequest
                .Include(x => x.Customer)
                .ThenInclude(x => x.CustomerContact)
                .Include(x => x.PreprationRequestDetailes)
                //.ThenInclude(x=>x.Subject)
                //.Include(x=>x.PreparationRequestType)
                .Include(x => x.PraparationDelivery).ToListAsync();

            if (preparationRequest == null)
            {
                return NotFound();
            }
            
            return preparationRequest;
        }

        // PUT: api/PreparationRequest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPreparationRequest(long id, PreparationRequest preparationRequest)
        {
            if (id != preparationRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(preparationRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreparationRequestExists(id))
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

        [HttpGet("/PreparationCodeGenerator")]
        public String generateCode(int PreparationType)
        {
            switch (PreparationType)
            {
                case 1:
                    return $"E-{Guid.NewGuid().ToString().GetHashCode():x}";//.ToString(x)

                case 2:
                    return $"S-{Guid.NewGuid().ToString().GetHashCode():x}";

                case 3:
                    return $"D-{Guid.NewGuid().ToString().GetHashCode():x}";

                default:
                    return $"{Guid.NewGuid().ToString().GetHashCode():x}";

            }

        }

        // POST: api/PreparationRequest
        [HttpPost]
        public async Task<ActionResult<PreparationRequest>> PostPreparationRequest(PreparationFullRequest preparationFullRequest)
        {
            //Validation
            if (SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart") != null)
            {
                String AllowedEmail = "^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$";


                if (preparationFullRequest.Name != null
                    && preparationFullRequest.customerContacts.Count != 0
                    && preparationFullRequest.PreparationRequestTypeId != 0/*1,2,3 only*/
                    && preparationFullRequest.PreparationRequestTypeId != -1
                    &&
                    (
                    (preparationFullRequest.PreparationRequestTypeId == 2 && preparationFullRequest.StoreId != 0
                    && preparationFullRequest.customerContacts
                    .Find(x => x.ContactTypeId == 2/*phone*/) != null)

                    || (preparationFullRequest.PreparationRequestTypeId == 3 && preparationFullRequest.ShippingId != 0
                    && preparationFullRequest.customerContacts
                    .Find(x => x.ContactTypeId == 3/*address*/) != null)

                    || (preparationFullRequest.PreparationRequestTypeId == 1 && preparationFullRequest.customerContacts
                    .Find(x => x.ContactTypeId == 1) != null
                     && Regex.IsMatch(preparationFullRequest.customerContacts
                    .Find(x => x.ContactTypeId == 1).Contact, AllowedEmail))
                    )
                    )
                {


                    //customer
                    var customerInfo = new Customer
                    {
                        Name = preparationFullRequest.Name,
                    };
                    _context.Customer.Add(customerInfo);
                    await _context.SaveChangesAsync();

                    //CustomerInfo
                    //Multiple Contact
                    //email,Address,Phone "..Done
                    foreach (var item in preparationFullRequest.customerContacts)
                    {

                        var customerContact = new CustomerContact
                        {
                            CustomerId = customerInfo.Id,
                            ContactTypeId = item.ContactTypeId,
                            Contact = item.Contact

                        };
                        _context.CustomerContact.Add(customerContact);
                        await _context.SaveChangesAsync();

                    }

                    //PreparationRequest
                    var request = new PreparationRequest
                    {
                        Code = generateCode(preparationFullRequest.PreparationRequestTypeId),
                        CustomerId = customerInfo.Id,
                        //TotalPrice = SessionHelper.GetObjectFromJson<List<PreparationFullRequest>>(HttpContext.Session, "fullCart").Select(x => x.TotalPrice).FirstOrDefault(),
                        TotalPrice = SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart").Sum(item => item.Subject.Price),
                        PreparationRequestTypeId = preparationFullRequest.PreparationRequestTypeId
                    };
                    _context.PreparationRequest.Add(request);
                    await _context.SaveChangesAsync();

                    preparationFullRequest.Id = request.Id;

                    //PreparationDetails
                    foreach (var item in SessionHelper.GetObjectFromJson<List<PreprationRequestDetailes>>(HttpContext.Session, "cart"))
                    {
                        var detailes = new PreprationRequestDetailes()
                        {
                            PreparationRequestId = preparationFullRequest.Id,
                            SubjectId = item.SubjectId

                        };
                        _context.PreprationRequestDetailes.Add(detailes);

                        await _context.SaveChangesAsync();
                    }

                    //PreparationDelivery
                    if (preparationFullRequest.PreparationRequestTypeId == 2)//Store
                    {
                        if (preparationFullRequest.StoreId != 0)
                        {

                            var deliveryType = new PraparationDelivery
                            {
                                PreparationRequestId = preparationFullRequest.Id,
                                ShippingId = null,
                                StoreId = preparationFullRequest.StoreId

                            };
                            _context.PraparationDelivery.Add(deliveryType);
                            await _context.SaveChangesAsync();

                        }
                        else
                        {
                            return BadRequest("Please select the branch.");
                        }
                    }
                    else if (preparationFullRequest.PreparationRequestTypeId == 3)//Shipping
                    {
                        if (preparationFullRequest.ShippingId != 0)
                        {
                            var deliveryType = new PraparationDelivery
                            {
                                PreparationRequestId = preparationFullRequest.Id,
                                ShippingId = preparationFullRequest.ShippingId,
                                StoreId = null

                            };
                            _context.PraparationDelivery.Add(deliveryType);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            return BadRequest("Please select the Delivery.");
                        }
                    }

                    return CreatedAtAction("GetPreparationRequest", new { id = preparationFullRequest.Id }, request);
                }
                return BadRequest("Please fill the missing data");

            }
            return BadRequest("Your Cart is EMPTY! Please select at least one subject.");
        }

        // DELETE: api/PreparationRequest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PreparationRequest>> DeletePreparationRequest(long id)
        {
            var preparationRequest = await _context.PreparationRequest.FindAsync(id);
            if (preparationRequest == null)
            {
                return NotFound();
            }

            _context.PreparationRequest.Remove(preparationRequest);
            await _context.SaveChangesAsync();

            return preparationRequest;
        }

        private bool PreparationRequestExists(long id)
        {
            return _context.PreparationRequest.Any(e => e.Id == id);
        }
    }
}

// 15/05/1990
// 15/01/1996



