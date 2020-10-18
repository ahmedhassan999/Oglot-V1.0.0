using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class QuestionTarget
    {
        public QuestionTarget()
        {
            LessonQuestion = new HashSet<LessonQuestion>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Target { get; set; }

        public virtual ICollection<LessonQuestion> LessonQuestion { get; set; }
    }
}
