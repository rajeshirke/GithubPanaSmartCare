using System;
using System.Collections.Generic;
using System.Text;

namespace eWarranty.Core.ResponseModels
{
    public class OrderSummaryResponse
    {
        public decimal TotalAmount { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal SubTotalAmount { get; set; } = 0;
        public decimal TaxAmount { get; set; } = 0;
        public decimal ShippingFeeAmount { get; set; } = 0;
        public decimal NetAmount { get; set; } = 0;
    }

    public class OrderDetailSumResponse
    {
        public decimal TotalAmount { get; set; } = 0;
        public decimal DiscountAmount { get; set; } = 0;
        public decimal SubTotalAmount { get; set; } = 0;
        public decimal TaxAmount { get; set; } = 0;
        public decimal NetAmount { get; set; } = 0;
    }
}
