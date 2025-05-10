using System;
namespace eWarranty.Core.ResponseModels
{
    public class ServiceRequestChargeResponse
    {
        public int ServiceRequestChargeId { get; set; }
        public int ServiceChargeMasterId { get; set; }
        public long ServiceCostEstimationId { get; set; }

        public virtual ServiceChargeMasterResponse ServiceChargeMaster { get; set; }
    }
}
