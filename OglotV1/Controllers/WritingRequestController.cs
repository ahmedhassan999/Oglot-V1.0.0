using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OglotV1.Models;
using Microsoft.Extensions.FileProviders;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;

namespace OglotV1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee")]
    public class WritingRequestController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public static IWebHostEnvironment _environment;

        public WritingRequestController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<WritingRequest>>> GetWritingRequest()
        {
            var writingRequest = await _context.WritingRequest.ToListAsync();


            //foreach (var attachment in writingRequest)
            //{
            //    await _context.Entry(attachment).Collection(x => x.WritingAttachments).LoadAsync();

            //}
            //.Include(x => x.WritingAttachments)
            await _context.WritingRequest
                .Include(a => a.WritingConversionType)
                .Include(b => b.WritingDocumentType)
                .Include(c => c.WritingTimePeriod).ToListAsync();

            return await _context.WritingRequest.ToListAsync();
        }

      
        // GET: api/paused/{requestdatefrom}/{requestdateTo}
        [HttpGet("{requestdatefrom}/{requestdateTo}")]

        public async Task<ActionResult<IEnumerable<WritingRequest>>> GetWritingRequestHistory(DateTime requestdatefrom, DateTime requestdateTo)
        {
            var writingRequests = await _context.WritingRequest.Where(x => x.RequestDate >= requestdatefrom && x.RequestDate <= requestdateTo).ToListAsync();

            //foreach (var attachment in writingRequests)
            //{
            //    await _context.Entry(attachment).Collection(x => x.WritingAttachments).LoadAsync();

            //}
            await _context.WritingRequest.Include(a => a.WritingConversionType).Include(b => b.WritingDocumentType).Include(c => c.WritingTimePeriod).ToListAsync();
            return writingRequests;
        }

        // GET: api/WritingRequest/Paused
        [HttpGet("paused")]
        public async Task<ActionResult<IEnumerable<WritingRequest>>> GetPausedWritingRequest()
        {

            var PausedWritingRequests = await _context.WritingRequest.Where(x => x.Done == false).ToListAsync();

            foreach (var attachment in PausedWritingRequests)
            {
                await _context.Entry(attachment).Collection(x => x.WritingAttachments).LoadAsync();

            }
            await _context.WritingRequest.Include(a => a.WritingConversionType).Include(b => b.WritingDocumentType).Include(c => c.WritingTimePeriod).ToListAsync();
            return PausedWritingRequests;
        }


        // GET: api/WritingRequest/Done
        [HttpGet("Done")]
        public async Task<ActionResult<IEnumerable<WritingRequest>>> GetDoneWritingRequest()
        {
            var doneWritingRequest = await _context.WritingRequest.Where(x => x.Done == true).ToListAsync();

            foreach (var attachment in doneWritingRequest)
            {
                await _context.Entry(attachment).Collection(x => x.WritingAttachments).LoadAsync();

            }
            await _context.WritingRequest.Include(a => a.WritingConversionType).Include(b => b.WritingDocumentType).Include(c => c.WritingTimePeriod).ToListAsync();
            return doneWritingRequest;
        }

        // GET: api/WritingRequest/unPaid
        [HttpGet("unPaid")]
        public async Task<ActionResult<IEnumerable<WritingRequest>>> GetunPaidWritingRequest()
        {
            var unPaidWritingRequest = await _context.WritingRequest.Where(x => x.Paid == false).ToListAsync();

            foreach (var attachment in unPaidWritingRequest)
            {
                await _context.Entry(attachment).Collection(x => x.WritingAttachments).LoadAsync();

            }
            await _context.WritingRequest.Include(a => a.WritingConversionType).Include(b => b.WritingDocumentType).Include(c => c.WritingTimePeriod).ToListAsync();
            return unPaidWritingRequest;
        }

        // GET: api/WritingRequest/Paid
        [HttpGet("Paid")]
        public async Task<ActionResult<IEnumerable<WritingRequest>>> GetPaidWritingRequest()
        {
            var paidWritingRequest = await _context.WritingRequest.Where(x => x.Paid == true).ToListAsync();
            foreach (var attachment in paidWritingRequest)
            {
                await _context.Entry(attachment).Collection(x => x.WritingAttachments).LoadAsync();

            }
            await _context.WritingRequest.Include(a => a.WritingConversionType).Include(b => b.WritingDocumentType).Include(c => c.WritingTimePeriod).ToListAsync();
            return paidWritingRequest;
        }

        // GET: api/WritingRequest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WritingRequest>> GetWritingRequest(int id)
        {
            var writingRequest = await _context.WritingRequest.FindAsync(id);

            if (writingRequest == null)
            {
                return NotFound();
            }
            var specificWritingRequest = await _context.WritingRequest.Where(x => x.Id == id).ToListAsync();


            foreach (var attachment in specificWritingRequest)
            {
                await _context.Entry(attachment).Collection(x => x.WritingAttachments).LoadAsync();

            }
            await _context.WritingRequest.Include(a => a.WritingConversionType).Include(b => b.WritingDocumentType).Include(c => c.WritingTimePeriod).ToListAsync();
            return writingRequest;
        }

        // PUT: api/WritingRequest/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWritingRequest(int id, WritingRequest writingRequest)
        {
            if (id != writingRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(writingRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WritingRequestExists(id))
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

        // POST: api/WritingRequest
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<WritingRequest>> PostWritingRequest([FromForm] List<IFormFile> files, [FromForm] WritingRequest writingRequest)
        {
            if (files.Count != 0 || writingRequest.Notes != null)
            {

                if (writingRequest.WritingConversionTypeId != 0
                    && writingRequest.WritingDocumentTypeId != 0
                    && writingRequest.WritingTimePeriodId != 0)
                {


                    //Request itself
                    var request = new WritingRequest
                    {
                        Email = writingRequest.Email,
                        //RequestDate = Date.Now,
                        RequestDate = DateTime.Now,
                        CustomerName = writingRequest.CustomerName,
                        Done = false,
                        Notes = writingRequest.Notes,
                        PageNumber = writingRequest.PageNumber,
                        Paid = false,
                        Phone = writingRequest.Phone,
                        WritingConversionTypeId = writingRequest.WritingConversionTypeId,
                        WritingDocumentTypeId = writingRequest.WritingDocumentTypeId,
                        WritingTimePeriodId = writingRequest.WritingTimePeriodId,


                        TotalPrice = CalculateTotalPrice(writingRequest.WritingConversionTypeId, writingRequest.WritingDocumentTypeId, writingRequest.WritingTimePeriodId, writingRequest.PageNumber)

                    };
                    _context.WritingRequest.Add(request);
                    await _context.SaveChangesAsync();
                    writingRequest.Id = request.Id;
                    //Attachment
                    if (files != null)
                    {
                        foreach (var file in files)
                        {

                            if (file.Length > 0)
                            {
                                var fileName = string.Concat("Oglot_Writing_", file.FileName);
                                MemoryStream ms = new MemoryStream();

                                await file.CopyToAsync(ms);

                                //if (!Directory.Exists(_environment.WebRootPath + "\\upload\\"))
                                //{
                                //    Directory.CreateDirectory(_environment.WebRootPath + "\\upload\\");
                                //}
                                //using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\upload\\" + file.FileName))
                                //{
                                //   await file.CopyToAsync(fileStream);
                                //    await fileStream.FlushAsync();

                                //}
                                var attach = new WritingAttachment
                                {
                                    Attachment = ms.ToArray(),
                                    FileName = fileName,
                                    Filetype = file.ContentType,
                                    WritingRequestId = writingRequest.Id
                                };

                                _context.WritingAttachment.Add(attach);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    return CreatedAtAction("GetWritingRequest", new { id = request.Id }, request);
                }
                else
                {
                    return BadRequest(new { message = " يجب إختيار كلاً من نوع الكتابة، و نوع المستند، و وقت التسليم" });

                }
            }
            else
            {
                return BadRequest(new { message = "يجب إرفاق ملف أو كتابة ملاحظات" });
            }

        }

        [AllowAnonymous]
        [HttpGet("totalprice/{writingConversionTypeId}/{writingDocumentTypeId}/{timePeriodId}/{pageNo}")]
        public decimal CalculateTotalPrice(int writingConversionTypeId, int writingDocumentTypeId, int timePeriodId, int pageNo)
        {
            var itemPrice = (_context.WritingPrice.First(x => x.WritingConversionTypeId == writingConversionTypeId
            && x.WritingDocumentTypeId == writingDocumentTypeId
             && x.WritingTimePeriodId == timePeriodId).Price);
            var totalPrice = itemPrice * pageNo;
            return totalPrice;
        }
        [AllowAnonymous]
        [HttpGet("details/{writingConversionTypeId}/{writingDocumentTypeId}/{timePeriodId}/{pageNo}")]
        public ActionResult<WritingRequest> WritingRequestDetails(int writingConversionTypeId, int writingDocumentTypeId, int timePeriodId, int pageNo)
        {
            
            var totalPrice = CalculateTotalPrice(writingConversionTypeId, writingDocumentTypeId, timePeriodId, pageNo);
            var writingRequestDetails = new WritingRequest
            {
                PageNumber = pageNo,
                TotalPrice = totalPrice,
                WritingConversionType = _context.WritingConversionType.First(x => x.Id == writingConversionTypeId),
                WritingDocumentType = _context.WritingDocumentType.First(x => x.Id == writingDocumentTypeId),
                WritingTimePeriod = _context.WritingTimePeriod.First(x => x.Id == timePeriodId)
            };
            return writingRequestDetails;
        }

        // DELETE: api/WritingRequest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WritingRequest>> DeleteWritingRequest(int id)
        {
            var writingRequest = await _context.WritingRequest.FindAsync(id);
            if (writingRequest == null)
            {
                return NotFound();
            }

            _context.WritingRequest.Remove(writingRequest);
            await _context.SaveChangesAsync();

            return writingRequest;
        }

        private bool WritingRequestExists(int id)
        {
            return _context.WritingRequest.Any(e => e.Id == id);
        }
    }
}

