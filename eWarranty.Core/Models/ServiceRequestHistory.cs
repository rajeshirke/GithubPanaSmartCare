using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceRequestHistory
    {
        public long ServiceRequestHistoryId { get; set; }
        public long ServiceRequestId { get; set; }
        public int ServiceRequestStatusId { get; set; }
        public DateTime ServiceRequestUpdatedDatetime { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
        public virtual ServiceRequestStatu ServiceRequestStatus { get; set; }
    }
}
