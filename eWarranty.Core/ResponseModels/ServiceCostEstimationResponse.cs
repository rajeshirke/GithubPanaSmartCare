using System;
using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceCostEstimationResponse
    {
        public long ServiceCostEstimationId { get; set; }
        public long ServiceRequestId { get; set; }
        public DateTime EstimationCreationDate { get; set; }
        public bool? IsApprovedByCustomer { get; set; }
        public DateTime? EstimationApprovalDate { get; set; }
        public int? DiscountByPercentage { get; set; }
        public decimal? DiscountByAmount { get; set; }

       
        public virtual ICollection<ServiceCostEstimationPartChargeResponse> ServiceCostEstimationPartCharges { get; set; }
        public virtual ICollection<ServiceRequestChargeResponse> ServiceRequestCharges { get; set; }
        public virtual ICollection<ServiceCostEstimationOtherChargeResponse> ServiceCostEstimationOtherCharges { get; set; }
                                   
    }
}
