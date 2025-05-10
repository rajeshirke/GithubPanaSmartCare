using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class TechnicianLocationTracking
    {
        public long TechnicianLocationTrackingId { get; set; }
        public long PersonId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime LocationDatetime { get; set; }

        public virtual Person Person { get; set; }
    }
}
