using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class MessageTemplate
    {
        public int MessageTemplateId { get; set; }
        public int NotificationEventType { get; set; }
        public string ChannelTypeId { get; set; }
        public int LanguageId { get; set; }
        public string MessageSubject { get; set; }
        public string MessageContent { get; set; }
        public string Recipient { get; set; }

        public virtual Language Language { get; set; }
        public virtual MessageTemplateFileInfo MessageTemplateFileInfo { get; set; }
    }
}
