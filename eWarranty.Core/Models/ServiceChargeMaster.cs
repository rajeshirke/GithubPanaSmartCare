using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceChargeMaster
    {
        public ServiceChargeMaster()
        {
            ServiceRequestCharges = new HashSet<ServiceRequestCharge>();
        }

        public int ServiceChargeMasterId { get; set; }
        public int CountryId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int ServiceRequestTypeId { get; set; }
        public int ChargeTypeId { get; set; }
        public int? ProductClassificationId { get; set; }
        public decimal Rate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long? UpdatedByPersonId { get; set; }
        public string Description { get; set; }

        //[JsonIgnore]
        public string CurrencyName { get; set; }

        public virtual ChargeType ChargeType { get; set; }
        public virtual Country Country { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ServiceRequestType ServiceRequestType { get; set; }
        public virtual ICollection<ServiceRequestCharge> ServiceRequestCharges { get; set; }
    }
}
