using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OglotV1.Models
{
    public class PreparationFullRequest
    {
        //public PreparationRequest preparationRequest { get; set; }
        public long Id { get; set; }//requestId
        public string Code { get; set; }
        public decimal TotalPrice { get; set; }
        public long CustomerId { get; set; }
        [Required]
        public int PreparationRequestTypeId { get; set; }
        
        //public ICollection<Subject> Subjects { get; set; }
        public int SubjectId { get; set; }
        //public virtual Subject Subject { get; set; }
        // public Customer customer { get; set; }
        public string Name { get; set; }//customerName

        //public string Contact { get; set; }
        //public int ContactTypeId { get; set; }
        [Required]
        public List<CustomerContact> customerContacts { get; set; }

        public int StoreId { get; set; }
        public int ShippingId { get; set; }

        //public  ICollection<CustomerContact> CustomerContacts { get; set; }
        //public PreparationFullRequest()
        //{
        //    CustomerContacts = new HashSet<CustomerContact>();
        //}

    }
}
