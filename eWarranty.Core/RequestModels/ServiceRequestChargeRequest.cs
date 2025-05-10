using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class ServiceRequestChargeRequest
    {
        public int ServiceRequestChargeId { get; set; }
        public int ServiceChargeMasterId { get; set; }//---just pass this only from mobile
        public long ServiceCostEstimationId { get; set; }
    }
}
