using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AmcType
    {
        public AmcType()
        {
            AmcRequestMasters = new HashSet<AmcRequestMaster>();
        }

        public int AmcTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AmcRequestMaster> AmcRequestMasters { get; set; }
    }
}
