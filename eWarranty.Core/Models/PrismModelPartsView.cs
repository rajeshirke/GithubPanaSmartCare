using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PrismModelPartsView
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }
        public long PartId { get; set; }
        public string PartNumber { get; set; }
    }
}
