using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OglotV1.Models
{
    public class WritingPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int WritingConversionTypeId { get; set; }

        [Required]
        public int WritingDocumentTypeId { get; set; }

        [Required]
        public int WritingTimePeriodId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public virtual WritingConversionType WritingConversionType { get; set; }
        public virtual WritingDocumentType WritingDocumentType { get; set; }
        public virtual WritingTimePeriod WritingTimePeriod { get; set; }
    }
}
