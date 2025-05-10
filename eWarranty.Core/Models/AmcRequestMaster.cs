using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AmcRequestMaster
    {
        public AmcRequestMaster()
        {
            AmcRequestCustomers = new HashSet<AmcRequestCustomer>();
            AmcRequestMasterProductCategories = new HashSet<AmcRequestMasterProductCategory>();
        }

        public int AmcRequestMasterId { get; set; }
        public int ServiceCenterId { get; set; }
        public int AmcTypeId { get; set; }
        public string Description { get; set; }
        public int PeriodInMonths { get; set; }
        public decimal Rate { get; set; }
        public int CurrencyId { get; set; }
        public int? CountryId { get; set; }
        public int? AmcExpiryNotificationDays { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? CreatedByPersonId { get; set; }

        public virtual AmcType AmcType { get; set; }
        public virtual Country Country { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ICollection<AmcRequestCustomer> AmcRequestCustomers { get; set; }
        public virtual ICollection<AmcRequestMasterProductCategory> AmcRequestMasterProductCategories { get; set; }
    }
}
