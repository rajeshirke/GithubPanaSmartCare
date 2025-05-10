using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Request
    {
        public Request()
        {
            AmcRequestCustomers = new HashSet<AmcRequestCustomer>();
            PartRequests = new HashSet<PartRequest>();
            ProductApprovalRequests = new HashSet<ProductApprovalRequest>();
            ReturnOrderRequests = new HashSet<ReturnOrderRequest>();
        }

        public long RequestId { get; set; }
        public string RequestNumber { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? CountryId { get; set; }
        public int RequestTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdatedBy { get; set; }
        public int RequestStatusId { get; set; }

        public virtual RequestStatu RequestStatus { get; set; }
        public virtual RequestType RequestType { get; set; }
        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ICollection<AmcRequestCustomer> AmcRequestCustomers { get; set; }
        public virtual ICollection<PartRequest> PartRequests { get; set; }
        public virtual ICollection<ProductApprovalRequest> ProductApprovalRequests { get; set; }
        public virtual ICollection<ReturnOrderRequest> ReturnOrderRequests { get; set; }
    }
}
