using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class PraparationDelivery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long PreparationRequestId { get; set; }
        public int? StoreId { get; set; }
        public int? ShippingId { get; set; }

        public virtual PreparationRequest PreparationRequest { get; set; }
        public virtual Shipping Shipping { get; set; }
        public virtual Store Store { get; set; }
    }
}
