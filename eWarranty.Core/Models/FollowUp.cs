using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class FollowUp
    {
        public long FollowUpId { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public int? ChannelTypeId { get; set; }
        public long FromPersonId { get; set; }
        public long ToPersonId { get; set; }
        public long? ServiceRequestId { get; set; }
        public int FollowUpTypeId { get; set; }

        public virtual FollowUpType FollowUpType { get; set; }
        public virtual Person FromPerson { get; set; }
        public virtual ServiceRequest ServiceRequest { get; set; }
        public virtual Person ToPerson { get; set; }
    }
}
