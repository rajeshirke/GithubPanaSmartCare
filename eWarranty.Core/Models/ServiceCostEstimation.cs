using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceCostEstimation
    {
        public ServiceCostEstimation()
        {
            ServiceCostEstimationPartCharges = new HashSet<ServiceCostEstimationPartCharge>();
            ServiceRequestCharges = new HashSet<ServiceRequestCharge>();
        }

        public long ServiceCostEstimationId { get; set; }
        public long ServiceRequestId { get; set; }
        public DateTime EstimationCreationDate { get; set; }
        public bool? IsApprovedByCustomer { get; set; }
        public DateTime? EstimationApprovalDate { get; set; }

        public virtual ServiceRequest ServiceRequest { get; set; }
        public virtual ICollection<ServiceCostEstimationPartCharge> ServiceCostEstimationPartCharges { get; set; }
        public virtual ICollection<ServiceRequestCharge> ServiceRequestCharges { get; set; }
    }
}
