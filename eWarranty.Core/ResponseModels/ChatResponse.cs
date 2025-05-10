using System;

namespace eWarranty.Core.ResponseModels
{
    public class ChatResponse
    {
        public long ChatId { get; set; }
        public long FromPersonId { get; set; }
        public DateTime ChatDate { get; set; }
        public long? ToPersonId { get; set; }
        public string Message { get; set; }
        public int? FileInfoId { get; set; }
        public string FromPersonName { get; set; }
        public string FromPersonRoleId { get; set; }
        public string FromPersonRole { get; set; }
        public string ToPersonName { get; set; }
        public string ToPersonRole { get; set; }
        public string ToPersonRoleId { get; set; }
        public string FileName { get; set; }
    }
}
