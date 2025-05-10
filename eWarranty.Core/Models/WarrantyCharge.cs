using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class WarrantyCharge
    {
        public int WarrantyChargeId { get; set; }
        public int ProductClassificationId { get; set; }
        public decimal Rate { get; set; }
        public int CountryId { get; set; }
        public int? ServiceCenterId { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedByPersonId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
    }
}
