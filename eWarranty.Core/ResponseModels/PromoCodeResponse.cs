using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class PromoCodeResponse
    {
        public int PromoCodeId { get; set; }
        public string Code { get; set; }
        public decimal? DiscountAmount { get; set; }
        public int? DiscountPercentage { get; set; }
        public decimal PromoCodeAmountCalculated { get; set; }
    }
}
