using System;
using System.Collections.Generic;

namespace eWarranty.Core.RequestModels
{
    public class CreateCostEstimationPartCharges
    {
        public long ServiceRequestId { get; set; }
        public int ServiceCostEstimationId { get; set; }
        public DateTime EstimationCreationDate { get; set; }
        public bool IsApprovedByCustomer { get; set; }
        public DateTime EstimationApprovalDate { get; set; }
        public bool Status { get; set; }
        public List<ServiceRequestCharges> ServiceRequestCharges { get; set; }
        public List<ServiceCostEstimationPartCharges> ServiceCostEstimationPartCharges { get; set; }
    }
    public class ServiceRequestCharges
    {
        public int ServiceRequestChargeId { get; set; }
        public int ServiceChargeMasterId { get; set; }
        public int ServiceCostEstimationId { get; set; }

    }
    public class ServiceCostEstimationPartCharges
    {
        public int ServiceCostEstimationPartChargeId { get; set; }
        public int ServiceCostEstimationId { get; set; }
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal PartTotalCost { get; set; }

    }
}
