using System;
namespace eWarranty.Core.RequestModels
{
    public class TechnicianQueryRequest
    {
        
        public int TechnicianQueryId { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public string Subject { get; set; }
        public string QueryContent { get; set; }
        public int? ProductClassificationId { get; set; }
        public string Status { get; set; }
        public long? CreatedByPersonId { get; set; }
    }
}
