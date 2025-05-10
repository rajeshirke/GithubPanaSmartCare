using System;
using System.Collections.Generic;

namespace eWarranty.Core.Models
{
    public class ChatBot
    {
        public string DataAlignment { get; set; }
        public string EventName { get; set; }
        public string ContentLink { get; set; }
        public List<Root> listEvents { get; set; }

    }

    public class Root
    {
        public int id { get; set; }
        public string qadescription { get; set; }
        public string otherMessage { get; set; }
        public int parentId { get; set; }
        public object qatypeID { get; set; }
        public string contentLink { get; set; }
    }

    public class ChatBotRequest {
        public string enquiryMessage { get; set; }
        public int customerPersonId { get; set; }
    }
}
