using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.Common
{
    public class Password
    {
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
    }
}
