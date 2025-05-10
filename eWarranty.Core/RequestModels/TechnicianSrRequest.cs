using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
   public class TechnicianSrRequest
    {
        public int TechnicianPersonId { get; set; }
        public int? ServiceRequestStatusId { get; set; }
        public DateTime? ServiceRequestDate { get; set; }
        public int? ServiceRequestAddressId { get; set; }
        public int? TechnicianMobileDashboardStatusId { get; set; }


    }
}
