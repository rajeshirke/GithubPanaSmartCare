using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CustomerFeedback
    {
        public CustomerFeedback()
        {
            FeedbackQuestionAnswers = new HashSet<FeedbackQuestionAnswer>();
        }

        public long CustomerFeedbackId { get; set; }
        public long ServiceRequestId { get; set; }
        public long CustomerPersonId { get; set; }
        public DateTime? CreatedOn { get; set; }

        public virtual Person CustomerPerson { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
        public virtual ICollection<FeedbackQuestionAnswer> FeedbackQuestionAnswers { get; set; }
    }
}
