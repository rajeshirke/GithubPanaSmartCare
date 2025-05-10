using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWarranty.Core.Enums;
 

namespace eWarranty.Core.RequestModels
{
    public class GetUserIdByTokenValueQuery
    {
        public string TokenValue { get; set; }
        public TokenContextEnum TokenContext { get; set; }
    }
}
