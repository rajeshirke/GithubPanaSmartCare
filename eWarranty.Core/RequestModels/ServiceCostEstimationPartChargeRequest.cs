using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class ServiceCostEstimationPartChargeRequest
    {
        public int ServiceCostEstimationPartChargeId { get; set; }
        public long ServiceCostEstimationId { get; set; }
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal? PartTotalCost { get; set; }
    }
}
