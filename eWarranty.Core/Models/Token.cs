using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class Token
    {
        public int TokenId { get; set; }
        public int TokenContextId { get; set; }
        public Guid UserId { get; set; }
        public string Value { get; set; }
        public DateTime ExpireTime { get; set; }
        public int FailedAttempts { get; set; }

        public virtual TokenContext TokenContext { get; set; }
    }
}
