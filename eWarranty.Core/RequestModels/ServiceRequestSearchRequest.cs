using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class ServiceRequestSearchRequest
    {
        public long? ServiceRequestId { get; set; }
        //public string ServiceRequestNumber { get; set; }
        public int? ServiceCenterId { get; set; } 
        //public DateTime StartDateTime { get; set; }
        //public DateTime EndDateTime { get; set; }
        public int? TypeId { get; set; }
        public int? StatusId { get; set; }
        public long? CustomerPersonId { get; set; } 
        //public long ProductModelId { get; set; } 
        //public DateTime CustomerSrpreferredDateTime { get; set; }
        //public int ProductWarrantyTypeId { get; set; }
        //public int ProductWarrantyStatusId { get; set; }
        //public int PriorityId { get; set; }
        //public int PromoCodeId { get; set; }
        //public decimal EstimatedWorkDurationHours { get; set; }
          
        public long? TechnicianPersonId { get; set; }
        //public int ServiceLocationTypeId { get; set; }
        //public DateTime LastUpdatedDate { get; set; }
        //public DateTime CreationDate { get; set; }
    }
}
