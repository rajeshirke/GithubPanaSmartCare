using System;
using System.Collections.Generic;

namespace eWarranty.Core.RequestModels
{
    public class CustomerFeedbackRequest
    {
        public long ServiceRequestId { get; set; }
        public long CustomerPersonId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<FeedbackQuestionAnswerRequest> FeedbackQuestionAnswers { get; set; }
    }

    public class FeedbackQuestionAnswerRequest
    {
        public long FeedbackQuestionId { get; set; }
        public long? FeedbackAnswerId { get; set; }
        public int? FeedbackRating { get; set; }
        public string OpenMessage { get; set; }
    }
}
