using System;

namespace eWarranty.Core.ResponseModels
{
    public class ChatbotEnquiryResponse
    {
        public long ChatbotEnquiryId { get; set; }
        public long CustomerPersonId { get; set; }
        public string EnquiryMessage { get; set; }
        public DateTime RequestedOn { get; set; }
        public int? AssignedPersonRoleId { get; set; }
        public long? AssignedPersonId { get; set; }
        public DateTime? ResolvedOn { get; set; }
        public string EnquiryRespondMessage { get; set; }
        public int? ChatEnquiryStatusId { get; set; }

        public string AssignedPersonName { get; set; }
        public string CustomerPersonName { get; set; } 


    }
}
