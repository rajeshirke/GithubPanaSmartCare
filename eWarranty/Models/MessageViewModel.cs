using System;
namespace eWarranty.Models
{
    public class MessageViewModel
    {
        public long id { get; set; }
        public long Personid { get; set; }
        private string text;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private DateTime messageDateTime;

        public DateTime MessagDateTime
        {
            get { return messageDateTime; }
            set { messageDateTime = value;  }
        }

        private bool isIncoming;

        public bool IsIncoming
        {
            get { return isIncoming; }
            set { isIncoming = value;  }
        }

        public bool HasAttachement => !string.IsNullOrEmpty(attachementUrl);

        private string attachementUrl;

        public string AttachementUrl
        {
            get { return attachementUrl; }
            set { attachementUrl = value;  }
        }


    }
}