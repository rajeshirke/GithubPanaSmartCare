using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class FeedbackAnswer
    {
        public FeedbackAnswer()
        {
            FeedbackQuestionAnswers = new HashSet<FeedbackQuestionAnswer>();
        }

        public long FeedbackAnswerId { get; set; }
        public long FeedbackQuestionId { get; set; }
        public string Answer { get; set; }

        public virtual FeedbackQuestion FeedbackQuestion { get; set; }
        public virtual ICollection<FeedbackQuestionAnswer> FeedbackQuestionAnswers { get; set; }
    }
}
