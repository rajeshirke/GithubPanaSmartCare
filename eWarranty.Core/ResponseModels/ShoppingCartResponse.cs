using System.Collections.Generic;

namespace eWarranty.Core.ResponseModels
{
    public class ShoppingCartResponse
    {
        public long ShoppingCartItemId { get; set; }
        public long? CustomerPersonId { get; set; }
        public long AccessoryMasterId { get; set; }
        public int Quantity { get; set; }
        public string AccessoryName { get; set; }
        public decimal AccessoryPrice { get; set; }
        public string AccessoryDescription { get; set; }
        public string ServiceCenterName { get; set; }

        public virtual ICollection<AccessoryFileResponse> AccessoryFiles { get; set; }
    }
}
