using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class ServiceChargeMasterSearchRequest
    {
        public int? ServiceChargeMasterId { get; set; }
        public int CountryId { get; set; }
        public int ServiceCenterId { get; set; }
        public int? ServiceRequestTypeId { get; set; }
        public int? ChargeTypeId { get; set; }
        public int ProductClassificationId { get; set; } 

    }
}
