using System;
using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{
    public class ServiceCostEstimationCustomerResponse
    {
        public long ServiceCostEstimationId { get; set; }
        public long ServiceRequestId { get; set; }
        public DateTime EstimationCreationDate { get; set; }
        public bool? IsApprovedByCustomer { get; set; }
        public DateTime? EstimationApprovalDate { get; set; }
        public int? DiscountByPercentage { get; set; }
        public decimal? DiscountByAmount { get; set; }
        public decimal? DiscountAmount { get; set; } //other discount 

        //---------------------
        public decimal SubTotal { get; set; }
        public decimal FinalDiscount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal TaxPercentage { get; set; }
        public string TaxName { get; set; }
        public decimal TotalAmount { get; set; }

        

        public PromoCodeResponse PromoCodeResponse { get; set; }//---ADDED TO DISPLAY the promocode data

        public virtual ICollection<ServiceCostEstimationPartChargeResponse> ServiceCostEstimationPartCharges { get; set; }
        public virtual ICollection<ServiceRequestChargeResponse> ServiceRequestCharges { get; set; }
        public virtual ICollection<ServiceCostEstimationOtherChargeResponse> ServiceCostEstimationOtherCharges { get; set; }
    }
}
