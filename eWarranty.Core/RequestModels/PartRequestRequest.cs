using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class PartRequestRequest
    {
        public int PartRequestId { get; set; }
        public string PartRequestNumber { get; set; }
        public long? ServiceRequestId { get; set; }
        public int ServiceCenterId { get; set; }
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
        public long? RequestId { get; set; }
    }
}
