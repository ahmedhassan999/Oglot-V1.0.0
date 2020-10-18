using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OglotV1.Models
{
    public class WritingAttachment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FileName { get; set; }
        public string Filetype { get; set; }

        [Required]
        public byte[] Attachment { get; set; }

         public int WritingRequestId { get; set; }

    }
}
