using eWarranty.Core.ExtraModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class EmailMobileVerificationTokenRequest 
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public int TokenContextId { get; set; }
        public Guid UserId { get; set; }
        public string Value { get; set; }
        
    }
}
