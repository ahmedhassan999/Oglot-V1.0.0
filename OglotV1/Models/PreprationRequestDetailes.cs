using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class PreprationRequestDetailes
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long PreparationRequestId { get; set; }
        public int SubjectId { get; set; }

        public virtual PreparationRequest PreparationRequest { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
