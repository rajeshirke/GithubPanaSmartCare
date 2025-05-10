using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
     public  class RequestCreateRequest
    {
        public long RequestId { get; set; }
        public string RequestNumber { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? CountryId { get; set; }
        public int RequestTypeId { get; set; }
        public DateTime CreationDate { get; set; }
        public long CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public long? UpdatedBy { get; set; }
        public int? RequestStatusId { get; set; }
    }
}
