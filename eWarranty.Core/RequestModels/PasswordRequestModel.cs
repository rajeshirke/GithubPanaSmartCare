using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class PasswordRequestModel
    {
        public string CurrentPassword { get; set; }

        //[PasswordValidation]
        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
        public string ReturnUrl { get; set; }
        public string Language { get; set; }
        public string Email { get; set; }
        public Guid UserID { get; set; }


    }
}
