using System;
namespace eWarranty.Core.ResponseModels
{
    public class FollowUpResponse
    {
        public long FollowUpId { get; set; }
        public string MessageContent { get; set; }
        public DateTime CreatedDatetime { get; set; }
        public int? ChannelTypeId { get; set; }
        public long FromPersonId { get; set; }
        public long ToPersonId { get; set; }
        public long? ServiceRequestId { get; set; }
        public int FollowUpTypeId { get; set; }

        public string FollowUpTypeName { get; set; }//---extra prop
        public string FromPersonName { get; set; }//---extra prop
        public string ToPersonName { get; set; }//---extra prop
        public string ToPersonRoleId { get; set; }//---extra prop
        public string FromPersonRoleId { get; set; }//---extra prop
        public string ToPersonRoleName { get; set; }//---extra prop
        public string FromPersonRoleName { get; set; }//---extra prop

    }
}
