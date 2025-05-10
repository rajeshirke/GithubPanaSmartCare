using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PartRequestType
    {
        public PartRequestType()
        {
            PartRequests = new HashSet<PartRequest>();
        }

        public int PartRequestTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PartRequest> PartRequests { get; set; }
    }
}
