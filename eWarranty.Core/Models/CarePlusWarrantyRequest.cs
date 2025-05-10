using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class CarePlusWarrantyRequest
    {
        public int CarePlusWarrantyRequestId { get; set; }
        public int RequestedByUserId { get; set; }
        public int CarePlusWarrantyRequestStatusId { get; set; }
        public DateTime RequestedDate { get; set; }
    }
}
