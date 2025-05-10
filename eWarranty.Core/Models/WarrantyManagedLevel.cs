using System;
using System.Collections.Generic;

namespace eWarranty.Core.Models
{
    public partial class WarrantyManagedLevel
    {
        public int WarrantyManagedLevelId { get; set; }
        public string Name { get; set; }
        public int? ServiceCenterId { get; set; }
    }
}
