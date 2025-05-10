using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AmcRequestCustomer
    {
        public int AmcRequestId { get; set; }
        public int AmcrequestMasterId { get; set; }
        public long ProductModelId { get; set; }
        public long? RequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long? ApprovedByPersonId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int AmcRequestStatusId { get; set; }
        public int? PromoCodeId { get; set; }
        public long? CustomerId { get; set; }

        public virtual AmcRequestStatu AmcRequestStatus { get; set; }
        public virtual AmcRequestMaster AmcrequestMaster { get; set; }
        public virtual Person ApprovedByPerson { get; set; }
        public virtual Person Customer { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual PromoCode PromoCode { get; set; }
        public virtual Request Request { get; set; }
    }
}
