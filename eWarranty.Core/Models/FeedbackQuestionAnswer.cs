using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class FeedbackQuestionAnswer
    {
        public long FeedbackQuestionAnswerId { get; set; }
        public long FeedbackQuestionId { get; set; }
        public long? FeedbackAnswerId { get; set; }
        public int? FeedbackRating { get; set; }
        public string OpenMessage { get; set; }
        public long? CustomerFeedbackId { get; set; }

        public virtual CustomerFeedback CustomerFeedback { get; set; }
        public virtual FeedbackAnswer FeedbackAnswer { get; set; }
        public virtual FeedbackQuestion FeedbackQuestion { get; set; }
    }
}
