using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class AmcRequestCustomerRequest
    {
        public int AmcRequestId { get; set; }
        public int AmcrequestMasterId { get; set; }
        public long ProductModelId { get; set; }
        public long? RequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? ApprovedByPersonId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int AmcRequestStatusId { get; set; }
        public int? PromoCodeId { get; set; }
        public long? CustomerId { get; set; }
    }
}
