using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OglotV1.Models;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee")]
    public class WritingPriceController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public dynamic crossJoinLinq;
        public List<WritingRequestTypes> itemToRemove = new List<WritingRequestTypes>();
        public WritingPriceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/WritingPrice
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WritingPrice>>> GetWritingPrice()
        {
            return await _context.WritingPrice.ToListAsync();
        }

        // GET: api/WritingPrice/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<WritingPrice>> GetWritingPrice(int id)
        {
            var writingPrice = await _context.WritingPrice.FindAsync(id);

            if (writingPrice == null)
            {
                return NotFound();
            }

            return writingPrice;
        }

        /// <summary>
        /// For Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("priced")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<WritingRequestTypes>>> GetPricedWritingRequest()
        {
            var types = await (from price in _context.WritingPrice
                               select new WritingRequestTypes
                               {

                                   WritingConversionType = price.WritingConversionType,

                                   WritingDocumentType = price.WritingDocumentType,

                                   WritingTimePeriod = price.WritingTimePeriod,
                               }).ToListAsync();

            if (types == null)
            {
                return NotFound();
            }

            return types;
        }
        /// <summary>
        /// For Admin
        /// </summary>
        /// <returns></returns>
        [HttpGet("unPriced")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<WritingRequestTypes>>> GetUnPricedWritingRequest()
        {
            //priced
            var priced = await (from price in _context.WritingPrice
                                join x in _context.WritingConversionType on price.WritingConversionTypeId equals x.Id

                                select new WritingRequestTypes
                                {
                                    WritingConversionType = price.WritingConversionType,

                                    WritingDocumentType = price.WritingDocumentType,

                                    WritingTimePeriod = price.WritingTimePeriod,
                                }).ToListAsync();
            //defered query execution  //all
            crossJoinLinq = await (from cv in _context.WritingConversionType
                                   from d in _context.WritingDocumentType
                                   from t in _context.WritingTimePeriod

                                       //where customer.CustId == car.SoldTo  
                                   select new WritingRequestTypes
                                   {
                                       WritingConversionType = cv,

                                       WritingDocumentType = d,

                                       WritingTimePeriod = t,
                                   }).ToListAsync();


            foreach (var item in priced)
            {
                foreach (var crossItem in crossJoinLinq)
                {
                    if (item.WritingConversionType.Id == crossItem.WritingConversionType.Id
                        && item.WritingDocumentType.Id == crossItem.WritingDocumentType.Id
                        && item.WritingTimePeriod.Id == crossItem.WritingTimePeriod.Id
                        )
                    {
                        itemToRemove.Add(crossItem);

                    }
                }
            }

            RemovePricedWritingRequest();


            if (crossJoinLinq == null)
            {
                return NotFound();
            }

            return crossJoinLinq;
        }

       /// <summary>
       /// for User
       /// </summary>
       /// <returns></returns>
        // GET: api/PricedConversionType/5
        [AllowAnonymous]
        [HttpGet("PricedConversionType")]
        public async Task<ActionResult<IEnumerable<WritingConversionType>>> GetPricedConversionType()
        {
            var @WritingConversionType = await _context.WritingPrice
                .Select(y => y.WritingConversionType).Distinct().ToListAsync();

            if (@WritingConversionType == null)
            {
                return NotFound();
            }

            return @WritingConversionType;
        }

        // GET: api/PricedDocumentType/5
        [AllowAnonymous]
        [HttpGet("PricedDocumentType/{writingConversionTypeId}")]
        public async Task<ActionResult<IEnumerable<WritingDocumentType>>> GetPricedDocumentType(int writingConversionTypeId)
        {
            var @WritingDocumentType = await _context.WritingPrice.Where(x => x.WritingConversionTypeId == writingConversionTypeId)
                .Select(y => y.WritingDocumentType).Distinct().ToListAsync();

            if (@WritingDocumentType == null)
            {
                return NotFound();
            }

            return @WritingDocumentType;
        }

        // GET: api/PricedTimePeriodType/4/5
        [AllowAnonymous]
        [HttpGet("PricedTimePeriodType/{writingConversionTypeId}/{writingDocumentTypeId}")]
        public async Task<ActionResult<IEnumerable<WritingTimePeriod>>> GetPricedTimePeriodType(int writingConversionTypeId, int writingDocumentTypeId)
        {
            var @WritingTimePeriod = await _context.WritingPrice.Where(x => x.WritingConversionTypeId == writingConversionTypeId).Where(x => x.WritingDocumentTypeId == writingDocumentTypeId)
                .Select(y => y.WritingTimePeriod).Distinct().ToListAsync();

            if (@WritingTimePeriod == null)
            {
                return NotFound();
            }

            return @WritingTimePeriod;
        }


        [HttpGet("removePriced")]
        [AllowAnonymous]
        private ActionResult<IEnumerable<WritingRequestTypes>> RemovePricedWritingRequest()
        {

            foreach (var index in itemToRemove)
            {
                crossJoinLinq.Remove(index);
            }

            if (crossJoinLinq == null)
            {
                return NotFound();
            }

            return crossJoinLinq;
        }
        // PUT: api/WritingPrice/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWritingPrice(int id, WritingPrice writingPrice)
        {
            if (id != writingPrice.Id)
            {
                return BadRequest();
            }

            _context.Entry(writingPrice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WritingPriceExists(id))
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

        // POST: api/WritingPrice
        [HttpPost]
        public async Task<ActionResult<WritingPrice>> PostWritingPrice(WritingPrice writingPrice)
        {
            _context.WritingPrice.Add(writingPrice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWritingPrice", new { id = writingPrice.Id }, writingPrice);
        }

        // DELETE: api/WritingPrice/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WritingPrice>> DeleteWritingPrice(int id)
        {
            var writingPrice = await _context.WritingPrice.FindAsync(id);
            if (writingPrice == null)
            {
                return NotFound();
            }

            _context.WritingPrice.Remove(writingPrice);
            await _context.SaveChangesAsync();

            return writingPrice;
        }

        private bool WritingPriceExists(int id)
        {
            return _context.WritingPrice.Any(e => e.Id == id);
        }
    }
}
