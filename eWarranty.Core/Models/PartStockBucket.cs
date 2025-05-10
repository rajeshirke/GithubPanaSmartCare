using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PartStockBucket
    {
        public PartStockBucket()
        {
            PartStockMasters = new HashSet<PartStockMaster>();
        }

        public int PartStockBucketId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsCostApplicable { get; set; }

        public virtual ICollection<PartStockMaster> PartStockMasters { get; set; }
    }
}
