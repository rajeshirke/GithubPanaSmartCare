using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceRequestType
    {
        public ServiceRequestType()
        {
            FeedbackQuestions = new HashSet<FeedbackQuestion>();
            ServiceChargeMasters = new HashSet<ServiceChargeMaster>();
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public int ServiceRequestTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FeedbackQuestion> FeedbackQuestions { get; set; }
        public virtual ICollection<ServiceChargeMaster> ServiceChargeMasters { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
