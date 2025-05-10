using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWarranty.Core.Enums
{

    public enum TokenContextEnum 
    {
        /// <summary>
        /// Verify email context
        /// </summary>
        EmailVerification = 1,
        /// <summary>
        /// Verify phone context
        /// </summary>
        OneTimePassword,
        /// <summary>
        /// Reset password context
        /// </summary>
        ResetPassword
    }
}
