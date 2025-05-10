using System;
namespace eWarranty.Core.RequestModels
{
    public class TechnicianWithLimitedDataRequest
    {
        public int ServiceCenterId { get; set; }
        public int PersonRoleId { get; set; }
        public int ProductCategoryId { get; set; }
        public DateTime CustomerSRPreferredDateTime { get; set; }
    }
}
