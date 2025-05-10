using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceRequestCharge
    {
        public int ServiceRequestChargeId { get; set; }
        public int ServiceChargeMasterId { get; set; }
        public long ServiceCostEstimationId { get; set; }

        public virtual ServiceChargeMaster ServiceChargeMaster { get; set; }
        public virtual ServiceCostEstimation ServiceCostEstimation { get; set; }
    }
}
