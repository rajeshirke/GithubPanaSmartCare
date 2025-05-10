using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class FollowUpType
    {
        public FollowUpType()
        {
            FollowUps = new HashSet<FollowUp>();
        }

        public int FollowUpTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FollowUp> FollowUps { get; set; }
    }
}
