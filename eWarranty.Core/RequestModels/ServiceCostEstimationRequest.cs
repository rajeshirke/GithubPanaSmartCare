using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class ServiceCostEstimationRequest
    {
        public long serviceRequestId { get; set; }
        public int serviceCostEstimationId { get; set; }
        public DateTime estimationCreationDate { get; set; }
        public bool isApprovedByCustomer { get; set; }
        public DateTime estimationApprovalDate { get; set; }
        public int? DiscountByPercentage { get; set; }
        public decimal? DiscountByAmount { get; set; }
        public decimal? DiscountAmount { get; set; } //other discount 
        public int? PromoCodeId { get; set; }
        public string PromoCode { get; set; }
        public bool status { get; set; }
        public List<ServiceRequestChargeRequest> serviceRequestCharges { get; set; }
        public List<ServiceCostEstimationPartChargeRequest> serviceCostEstimationPartCharges { get; set; }
        public List<ServiceCostEstimationOtherChargeRequest> ServiceCostEstimationOtherCharges { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    //public class ServiceRequestCharge
    //{
    //    public int serviceRequestChargeId { get; set; }
    //    public int serviceChargeMasterId { get; set; }
    //    public int serviceCostEstimationId { get; set; }
    //}

    //public class ServiceCostEstimationPartCharge
    //{
    //    public int serviceCostEstimationPartChargeId { get; set; }
    //    public int serviceCostEstimationId { get; set; }
    //    public string partNumber { get; set; }
    //    public int cost { get; set; }
    //    public int quantity { get; set; }
    //    public int partTotalCost { get; set; }
    //}





}
