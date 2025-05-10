using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.RequestModels
{
    public class CreateInvoiceRequest
    { 
        public long ServiceRequestId { get; set; }
        //public bool IsPromoCodeApplied { get; set; }
        public int PaymentModeId { get; set; }
        public string Sign { get; set; }
        public decimal PaymentAmount { get; set; }
        public bool? IsServiceChargeable { get; set; }
    }
}
