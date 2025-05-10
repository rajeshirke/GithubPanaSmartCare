using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class FollowUpRequest
    {
        public long FollowUpId { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public int? ChannelTypeId { get; set; }
        public long FromPersonId { get; set; }
        public long ToPersonId { get; set; }
        public long? ServiceRequestId { get; set; }
        public int FollowUpTypeId { get; set; }
    }
}
