using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ProductApprovalRequestStatu
    {
        public ProductApprovalRequestStatu()
        {
            ProductApprovalRequests = new HashSet<ProductApprovalRequest>();
        }

        public int ProductApprovalRequestStatusId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProductApprovalRequest> ProductApprovalRequests { get; set; }
    }
}
