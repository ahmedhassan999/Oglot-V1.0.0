using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class PreparationRequest
    {
        public PreparationRequest()
        {
            PraparationDelivery = new HashSet<PraparationDelivery>();
            PreprationRequestDetailes = new HashSet<PreprationRequestDetailes>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Code { get; set; }
        public decimal TotalPrice { get; set; }
        public long CustomerId { get; set; }
        public int PreparationRequestTypeId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual PreparationRequestType PreparationRequestType { get; set; }
        public virtual ICollection<PraparationDelivery> PraparationDelivery { get; set; }
        public virtual ICollection<PreprationRequestDetailes> PreprationRequestDetailes { get; set; }
    }
}
