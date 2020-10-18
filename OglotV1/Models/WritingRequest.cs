using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.OData.Edm;

namespace OglotV1.Models
{
    public class WritingRequest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        /*[EmailAddress]*/
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        
        public string Phone { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter a valid postive number")]            
        public int PageNumber { get; set; }

        public string Notes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        //[DataType(DataType.Date)]
        public DateTime RequestDate { get; set; }

        public bool Paid { get; set; }

        public bool Done { get; set; }

        [Required]
        public int WritingConversionTypeId { get; set; }

        [Required]
        public int WritingDocumentTypeId { get; set; }

        [Required]
        public int WritingTimePeriodId { get; set; }

        public virtual WritingConversionType WritingConversionType { get; set; }
        public virtual WritingDocumentType WritingDocumentType { get; set; }
        public virtual WritingTimePeriod WritingTimePeriod { get; set; }


        public virtual ICollection<WritingAttachment> WritingAttachments { get; set; }

        public WritingRequest()
        {
            WritingAttachments = new HashSet<WritingAttachment>();
        }

    }
}
