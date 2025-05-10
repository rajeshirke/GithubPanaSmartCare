using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ModelPartStockView
    {
        public string ModelNumberMstr { get; set; }
        public string PartNumberMstr { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? PartStockBucketId { get; set; }
        public int? Quantity { get; set; }
        public long? TechnicianPersonId { get; set; }
    }
}
