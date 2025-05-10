using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class AmcRequestCustomerResponse
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
        public string AmcRequestStatusName { get; set; }
        public string AmcTypeName { get; set; }

        public int? PromoCodeId { get; set; } 
        public long? CustomerId { get; set; } 
        

        //public virtual AmcRequestStatu AmcRequestStatus { get; set; }
        public virtual AmcRequestMasterResponse AmcrequestMaster { get; set; }
        public virtual PersonDetailsResponse ApprovedByPerson { get; set; }
        public virtual PersonDetailsResponse Customer { get; set; }
        //public virtual ProductModelResponse ProductModel { get; set; }
        public virtual PromoCodeResponse PromoCode { get; set; }
        public virtual RequestResponse Request { get; set; }
    }
}
