using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OglotV1.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            AdditionalSupport = new HashSet<AdditionalSupport>();
            Evaluation = new HashSet<Evaluation>();
            HomeWork = new HashSet<HomeWork>();
            LearningMethodology = new HashSet<LearningMethodology>();
            LessonQuestion = new HashSet<LessonQuestion>();
            Objective = new HashSet<Objective>();
            Resource = new HashSet<Resource>();
            Strategy = new HashSet<Strategy>();
            Url = new HashSet<Url>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Intro { get; set; }
        public string LessonContent { get; set; }
        public string Notes { get; set; }
        public string LearningVarity { get; set; }
        public int SubjectId { get; set; }
        
        public virtual Subject Subject { get; set; }
        public virtual ICollection<AdditionalSupport> AdditionalSupport { get; set; }
        public virtual ICollection<Evaluation> Evaluation { get; set; }
        public virtual ICollection<HomeWork> HomeWork { get; set; }
        public virtual ICollection<LearningMethodology> LearningMethodology { get; set; }
        public virtual ICollection<LessonQuestion> LessonQuestion { get; set; }
        public virtual ICollection<Objective> Objective { get; set; }
        public virtual ICollection<Resource> Resource { get; set; }
        public virtual ICollection<Strategy> Strategy { get; set; }
        public virtual ICollection<Url> Url { get; set; }
    }
}
