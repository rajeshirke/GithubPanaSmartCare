using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceRequestTechnicianHistory
    {
        public long SrtechnicianHistoryId { get; set; }
        public long ServiceRequestId { get; set; }
        public long TechnicianPersonId { get; set; }
        public DateTime TechnicianAssignmentDate { get; set; }
        public string TechnicianAssignmentReason { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
