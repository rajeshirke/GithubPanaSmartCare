using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceCostEstimationPartCharge
    {
        public int ServiceCostEstimationPartChargeId { get; set; }
        public long ServiceCostEstimationId { get; set; }
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal? PartTotalCost { get; set; }

        public virtual ServiceCostEstimation ServiceCostEstimation { get; set; }
    }
}
