using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class QuestionType
    {
        public QuestionType()
        {
            FeedbackQuestions = new HashSet<FeedbackQuestion>();
            SurveyQuestions = new HashSet<SurveyQuestion>();
        }

        public int QuestionTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FeedbackQuestion> FeedbackQuestions { get; set; }
        public virtual ICollection<SurveyQuestion> SurveyQuestions { get; set; }
    }
}
