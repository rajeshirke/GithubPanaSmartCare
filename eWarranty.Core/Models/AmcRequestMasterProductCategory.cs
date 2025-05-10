using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AmcRequestMasterProductCategory
    {
        public int Id { get; set; }
        public int AmcRequestMasterId { get; set; }
        public int ProductClassificationId { get; set; }

        public virtual AmcRequestMaster AmcRequestMaster { get; set; }
    }
}
