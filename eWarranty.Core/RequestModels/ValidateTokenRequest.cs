using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWarranty.Core.RequestModels
{
    public class ValidateTokenRequest
    {
        public string TokenValue { get; set; }
        public int TokenContextId { get; set; } //- 1,2,3 enum
        public Guid UserId { get; set; }
    }
}
