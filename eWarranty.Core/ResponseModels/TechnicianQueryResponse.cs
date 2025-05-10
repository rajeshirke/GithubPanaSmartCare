using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class TechnicianQueryResponse
    {
        public int TechnicianQueryId { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Subject { get; set; }
        public string QueryContent { get; set; }
        public int? ProductClassificationId { get; set; }
        public int? ParentTechnicianQueryId { get; set; }
        public int? Hid { get; set; }    
        public string Status { get; set; }
        public long? CreatedByPersonId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ReferenceId { get; set; }
        public string QuerySolutionContent { get; set; }
    }
}
