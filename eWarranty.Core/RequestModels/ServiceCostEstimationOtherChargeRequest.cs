using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class ServiceCostEstimationOtherChargeRequest
    {
        public long ServiceCostEstimationOtherChargesId { get; set; }
        public long? ServiceRequestId { get; set; }
        public long? ServiceCostEstimationId { get; set; }
        public int ChargeTypeId { get; set; }
        public decimal OtherRate { get; set; } 
    }
}
