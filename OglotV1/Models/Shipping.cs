using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class Shipping
    {
        public Shipping()
        {
            PraparationDelivery = new HashSet<PraparationDelivery>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PraparationDelivery> PraparationDelivery { get; set; }
    }
}
