using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ChatbotEnquiry
    {
        public long ChatbotEnquiryId { get; set; }
        public long CustomerPersonId { get; set; }
        public string EnquiryMessage { get; set; }
        public DateTime RequestedOn { get; set; }
        public int? AssignedPersonRoleId { get; set; }
        public long? AssignedPersonId { get; set; }
        public DateTime? ResolvedOn { get; set; }

        public virtual Person AssignedPerson { get; set; }
        public virtual PersonRole AssignedPersonRole { get; set; }
        public virtual Person CustomerPerson { get; set; }
    }
}
