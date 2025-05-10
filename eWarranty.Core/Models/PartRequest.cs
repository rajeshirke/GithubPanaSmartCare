using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PartRequest
    {
        public int PartRequestId { get; set; }
        public string PartRequestNumber { get; set; }
        public long? ServiceRequestId { get; set; }
        public int ServiceCenterId { get; set; }
        public long? RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public long RequestedByTechnicianId { get; set; }
        public string PartNumber { get; set; }
        public int? PartUsedInServiceFromBucketId { get; set; }
        public int RequestedPartQuantity { get; set; }
        public int PartRequestTypeId { get; set; }
        public int PartRequestStatusId { get; set; }
        public string TechnicianRemark { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? UpdatedByPersonId { get; set; }
        public long? ServiceCostEstimationId { get; set; }

        public virtual PartRequestStatu PartRequestStatus { get; set; }
        public virtual PartRequestType PartRequestType { get; set; }
        public virtual Request Request { get; set; }
        public virtual Person RequestedByTechnician { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
        public virtual Person UpdatedByPerson { get; set; }
    }
}
