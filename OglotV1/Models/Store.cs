using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class Store
    {
        public Store()
        {
            PraparationDelivery = new HashSet<PraparationDelivery>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        public virtual ICollection<PraparationDelivery> PraparationDelivery { get; set; }
    }
}
