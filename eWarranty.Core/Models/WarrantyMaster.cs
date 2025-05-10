using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class WarrantyMaster
    {
        public WarrantyMaster()
        {
            WarrantyCustomerProducts = new HashSet<WarrantyCustomerProduct>();
        }

        public int WarrantyMasterId { get; set; }
        public int WarrantyTypeId { get; set; }
        public int WarrantyPeriodInMonths { get; set; }
        public int CountryId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int ProductClassificationId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedByPersonId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual WarrantyType WarrantyType { get; set; }
        public virtual ICollection<WarrantyCustomerProduct> WarrantyCustomerProducts { get; set; }
    }
}
