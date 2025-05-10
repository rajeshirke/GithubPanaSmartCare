using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PrismProductCategoryView
    {
        public int ProductClassificationId { get; set; }
        public int WebMasterId { get; set; }
        public string ProductClassification { get; set; }
        public byte ActiveStatus { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long VersionNo { get; set; }
        public long WebVersionNo { get; set; }
    }
}
