using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class WarrantyMasterView
    {
        public int WarrantyMasterId { get; set; }
        public int WarrantyTypeId { get; set; }
        public int WarrantyPeriodInMonths { get; set; }
        public int CountryId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int ProductClassificationId { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long UpdatedByPersonId { get; set; }
        public string ServiceCenterName { get; set; }
        public string CountryName { get; set; }
        public string ProductClassification { get; set; }
        public string UpdatedByPersonName { get; set; }
        public string WarrantyTypeName { get; set; }
    }
}
