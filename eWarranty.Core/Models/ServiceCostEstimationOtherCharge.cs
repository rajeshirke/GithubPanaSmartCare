using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceCostEstimationOtherCharge
    {
        public long ServiceCostEstimationOtherChargesId { get; set; }
        public long? ServiceRequestId { get; set; }
        public long? ServiceCostEstimationId { get; set; }
        public int ChargeTypeId { get; set; }
        public decimal OtherRate { get; set; }

        public virtual ChargeType ChargeType { get; set; }
        public virtual ServiceCostEstimation ServiceCostEstimation { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
    }
}
