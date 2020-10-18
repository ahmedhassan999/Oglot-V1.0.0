using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class Class
    {
        public Class()
        {
            Semester = new HashSet<Semester>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int StageId { get; set; }

        public virtual Stage Stage { get; set; }
        public virtual ICollection<Semester> Semester { get; set; }
    }
}
