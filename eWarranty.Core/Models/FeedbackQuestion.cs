using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class FeedbackQuestion
    {
        public FeedbackQuestion()
        {
            FeedbackAnswers = new HashSet<FeedbackAnswer>();
            FeedbackQuestionAnswers = new HashSet<FeedbackQuestionAnswer>();
        }

        public long FeedbackQuestionId { get; set; }
        public int ServiceRequestTypeId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionTypeId { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual ServiceRequestType ServiceRequestType { get; set; }
        public virtual ICollection<FeedbackAnswer> FeedbackAnswers { get; set; }
        public virtual ICollection<FeedbackQuestionAnswer> FeedbackQuestionAnswers { get; set; }
    }
}
