using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OglotV1.Models
{
    public class WritingRequestTypes
    {
        public WritingConversionType WritingConversionType { get; set; }
        public WritingDocumentType WritingDocumentType { get; set; }
        public WritingTimePeriod WritingTimePeriod { get; set; }
    }
}
