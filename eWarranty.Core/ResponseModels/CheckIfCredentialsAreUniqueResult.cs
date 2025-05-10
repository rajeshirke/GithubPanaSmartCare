using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWarranty.Core.ResponseModels
{
    public class CheckIfCredentialsAreUniqueResult
    {
        public bool CredentialsUnique { get; set; }
        public string ErrorMessage { get; set; }
    }
}
