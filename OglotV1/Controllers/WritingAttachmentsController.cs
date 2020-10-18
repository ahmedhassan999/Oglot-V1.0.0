using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OglotV1.Models;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.Net.Http.Headers;

namespace OglotV1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Employee")]
    public class WritingAttachmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public static IWebHostEnvironment _environment;

        public WritingAttachmentsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: api/WritingAttachments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WritingAttachment>>> GetWritingAttachment()
        {
            return await _context.WritingAttachment.ToListAsync();

        }

        // GET: api/WritingAttachments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WritingAttachment>> GetWritingAttachment(int id)
        {
            var writingAttachment = await _context.WritingAttachment.FindAsync(id);

            if (writingAttachment == null)
            {
                return NotFound();
            }
            //byte[] fileData = writingAttachment.Attachment;
            //Response.Headers.Add("Content-type", writingAttachment.Filetype);
            //Response.Headers.Add("Content-Disposition", "attachment; filename=" + writingAttachment.FileName);

            //var cd = new System.Net.Mime.ContentDisposition
            //{

            //    FileName = writingAttachment.FileName,

            //    // always prompt the user for downloading, set to true if you want 
            //    // the browser to try to show the file inline
            //    Inline = true,
            //    DispositionType= writingAttachment.Filetype
            //};
            ////Response.AppendHeader("Content-Disposition", cd.ToString());
            //Response.Headers.Add(HeaderNames.ContentDisposition, cd.ToString());
            //return File(System.IO.File.ReadAllBytes(writingAttachment.Attachment), "application/octet-stream", filename);
            return File(writingAttachment.Attachment, writingAttachment.Filetype, writingAttachment.FileName);//download
            
        }
        


        // PUT: api/WritingAttachments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWritingAttachment(int id, WritingAttachment writingAttachment)
        {
            if (id != writingAttachment.Id)
            {
                return BadRequest();
            }

            _context.Entry(writingAttachment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WritingAttachmentExists(id))
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

        // POST: api/WritingAttachments
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<WritingAttachment>> PostWritingAttachment(WritingAttachment writingAttachment)
        {
            _context.WritingAttachment.Add(writingAttachment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWritingAttachment", new { id = writingAttachment.Id }, writingAttachment);
        }

        // DELETE: api/WritingAttachments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WritingAttachment>> DeleteWritingAttachment(int id)
        {
            var writingAttachment = await _context.WritingAttachment.FindAsync(id);
            if (writingAttachment == null)
            {
                return NotFound();
            }

            _context.WritingAttachment.Remove(writingAttachment);
            await _context.SaveChangesAsync();

            return writingAttachment;
        }

        private bool WritingAttachmentExists(int id)
        {
            return _context.WritingAttachment.Any(e => e.Id == id);
        }

        //Try Upload environment
        //[HttpPost("/uploadFile")]

        //public async Task<ActionResult<WritingAttachment>> PostAttachment([FromForm] FileUpload file)
        //{
        //    if (file.files.Length > 0)
        //    {
        //        MemoryStream ms = new MemoryStream();
        //        file.files.CopyToAsync(ms);

        //        if (!Directory.Exists(_environment.WebRootPath + "\\upload\\"))
        //        {
        //            Directory.CreateDirectory(_environment.WebRootPath + "\\upload\\");
        //        }
        //        using (FileStream fileStream = System.IO.File.Create(_environment.WebRootPath + "\\upload\\" + file.files.FileName))
        //        {
        //            file.files.CopyToAsync(fileStream);
        //            fileStream.FlushAsync();

        //        }
        //        var attach = new WritingAttachment
        //        {
        //            Attachment = ms.ToArray(),
        //            WritingRequestId = 1
        //        };
        //        _context.WritingAttachment.Add(attach);
        //        await _context.SaveChangesAsync();
        //        return CreatedAtAction("GetWritingAttachment", new { id = attach.Id }, attach);
        //    }

        //    return BadRequest("No Files uploaded");

        //}


    }
}
