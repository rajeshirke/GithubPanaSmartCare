using eWarranty.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace eWarranty.Core.RequestModels
{
    public class GetUserIdByTokenValueRequest
    {
        public string TokenValue { get; set; }
        public TokenContextEnum TokenContext { get; set; }
    }
}
