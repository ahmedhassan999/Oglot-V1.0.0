﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class Url
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string URL { get; set; }
        public long LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }
    }
}
