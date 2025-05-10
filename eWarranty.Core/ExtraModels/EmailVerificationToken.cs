using eWarranty.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ExtraModels
{
  public  class EmailVerificationToken : Token
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
    }
}
