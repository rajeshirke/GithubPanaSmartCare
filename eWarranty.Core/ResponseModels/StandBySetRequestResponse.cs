using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
   public class StandBySetRequestResponse
    {
        public int StandBySetRequestId { get; set; }
        public long ProductModelId { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string StandBySetModelNumber { get; set; }
        public string StandBySetSerialNumber { get; set; }
        public long? StandBySetAssignedByPersonId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? StandBySetAssignmentDate { get; set; }
        public DateTime? RequestClosingDate { get; set; }
        public long ServiceRequestId { get; set; }
        public long? CustomerId { get; set; }
        public int StatusId { get; set; }
        public string Remark { get; set; }
        public long? RequestClosedByPersonId { get; set; }
    }
}
