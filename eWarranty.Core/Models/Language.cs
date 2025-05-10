using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Language
    {
        public Language()
        {
            CampaignLanguages = new HashSet<CampaignLanguage>();
            MessageTemplates = new HashSet<MessageTemplate>();
            Persons = new HashSet<Person>();
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CampaignLanguage> CampaignLanguages { get; set; }
        public virtual ICollection<MessageTemplate> MessageTemplates { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
