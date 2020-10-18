using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class LessonQuestion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public long LessonId { get; set; }
        public int QuestionTargetId { get; set; }

        public virtual Lesson Lesson { get; set; }
        public virtual QuestionTarget QuestionTarget { get; set; }
    }
}
