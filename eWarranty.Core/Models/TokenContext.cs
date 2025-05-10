using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class TokenContext
    {
        public TokenContext()
        {
            Tokens = new HashSet<Token>();
        }

        public int TokenContextId { get; set; }
        public string Name { get; set; }
        public int DurationInSeconds { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }
    }
}
