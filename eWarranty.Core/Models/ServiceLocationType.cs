using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ServiceLocationType
    {
        public ServiceLocationType()
        {
            ServiceRequests = new HashSet<ServiceRequest>();
        }

        public int ServiceLocationTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
    }
}
