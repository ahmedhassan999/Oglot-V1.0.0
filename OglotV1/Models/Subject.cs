using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Lesson = new HashSet<Lesson>();
            PreprationRequestDetailes = new HashSet<PreprationRequestDetailes>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int SemesterId { get; set; }
        public decimal Price { get; set; }

        public virtual Semester Semester { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
        public virtual ICollection<PreprationRequestDetailes> PreprationRequestDetailes { get; set; }
    }
}
