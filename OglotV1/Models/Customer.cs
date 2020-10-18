using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            CustomerContact = new HashSet<CustomerContact>();
            PreparationRequest = new HashSet<PreparationRequest>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomerContact> CustomerContact { get; set; }
        public virtual ICollection<PreparationRequest> PreparationRequest { get; set; }
    }
}
