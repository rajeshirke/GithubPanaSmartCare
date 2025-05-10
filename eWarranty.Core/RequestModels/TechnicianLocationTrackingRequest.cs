using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
   public class TechnicianLocationTrackingRequest
    {
        public long TechnicianLocationTrackingId { get; set; }
        public long PersonId { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public DateTime LocationDatetime { get; set; }
    }
}
