using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class PersonServiceCenter
    {
        public int PersonServiceCenterId { get; set; }
        public long PersonId { get; set; }
        public int ServiceCenterId { get; set; }

        public virtual Person Person { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
    }
}
