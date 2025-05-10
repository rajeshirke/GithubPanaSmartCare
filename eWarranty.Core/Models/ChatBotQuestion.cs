using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ChatBotQuestion
    {
        public ChatBotQuestion()
        {
            ChatBotAnswers = new HashSet<ChatBotAnswer>();
        }

        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public virtual ICollection<ChatBotAnswer> ChatBotAnswers { get; set; }
    }
}
