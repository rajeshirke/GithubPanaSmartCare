namespace eWarranty.Core.RequestModels
{
    public class ShoppingCartRequest
    {
        public long CustomerPersonId { get; set; }
        public long AccessoryMasterId { get; set; }
        public int Quantity { get; set; }
    }

    public class ShoppingCartUpdateRequest
    {
        public long ShoppingCartItemId { get; set; }
        public long AccessoryMasterId { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; }
    }
}
