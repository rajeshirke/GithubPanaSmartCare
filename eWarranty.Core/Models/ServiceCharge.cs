using System;
using System.Collections.Generic;

namespace eWarranty.Core.Models
{
    public partial class ServiceCharge
    {
        public ServiceCharge()
        {
            ServiceChargeProductCategories = new HashSet<ServiceChargeProductCategory>();
        }

        public int ServiceChargeId { get; set; }
        public int CountryId { get; set; }
        public int ServiceCenterId { get; set; }
        public int ServiceRequestTypeId { get; set; }
        public int ChargeTypeId { get; set; }
        public decimal Rate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public virtual ChargeType ChargeType { get; set; }
        public virtual Country Country { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ServiceRequestType ServiceRequestType { get; set; }
        public virtual ICollection<ServiceChargeProductCategory> ServiceChargeProductCategories { get; set; }
    }
}
