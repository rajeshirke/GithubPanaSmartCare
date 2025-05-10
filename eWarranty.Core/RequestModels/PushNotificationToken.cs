using System;
namespace eWarranty.Core.RequestModels
{
    public class PushNotificationToken
    {
        public long Id { get; set; }
        public long PersonId { get; set; }
        public string Token { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? OstypeId { get; set; }
        public string OstypeName { get; set; }
    }
}
