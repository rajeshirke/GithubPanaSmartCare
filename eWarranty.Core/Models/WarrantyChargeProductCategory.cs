using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class WarrantyChargeProductCategory
    {
        public int WarrantyChargeId { get; set; }
        public int ProductClassificationId { get; set; }
    }
}
