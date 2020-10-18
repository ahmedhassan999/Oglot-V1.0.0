using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class PreparationRequestType
    {
        public PreparationRequestType()
        {
            PreparationRequest = new HashSet<PreparationRequest>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<PreparationRequest> PreparationRequest { get; set; }
    }
}
