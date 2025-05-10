using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ProductApprovalRequest
    {
        public int ProductApprovalId { get; set; }
        public long ProductModelId { get; set; }
        public long? RequestId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public long? ApprovedByPersonId { get; set; }
        public int StatusId { get; set; }

        public virtual Person ApprovedByPerson { get; set; }
        public virtual ProductModel ProductModel { get; set; }
        public virtual Request Request { get; set; }
        public virtual ProductApprovalRequestStatu Status { get; set; }
    }
}
