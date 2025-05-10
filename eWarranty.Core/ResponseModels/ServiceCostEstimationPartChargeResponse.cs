using System;
namespace eWarranty.Core.ResponseModels
{
    public class ServiceCostEstimationPartChargeResponse
    {
        public int ServiceCostEstimationPartChargeId { get; set; }
        public long ServiceCostEstimationId { get; set; }
        public string PartNumber { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public decimal? PartTotalCost { get; set; }
        public string CurrencyName { get; set; }

    }
}
