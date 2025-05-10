using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class AccessoryMaster
    {
        public AccessoryMaster()
        {
            AccessoryFiles = new HashSet<AccessoryFile>();
            AccessoryMasterProductCategories = new HashSet<AccessoryMasterProductCategory>();
            AccessoryOrderDetails = new HashSet<AccessoryOrderDetail>();
            AccessoryStocks = new HashSet<AccessoryStock>();
            OrderDetails = new HashSet<OrderDetail>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public long AccessoryMasterId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ServiceCenterId { get; set; }
        public decimal? DeliveryCost { get; set; }
        public string DeliveryDays { get; set; }
        public string Specification { get; set; }
        public bool? IsActive { get; set; }

        public virtual ServiceCenter ServiceCenter { get; set; }
        public virtual ICollection<AccessoryFile> AccessoryFiles { get; set; }
        public virtual ICollection<AccessoryMasterProductCategory> AccessoryMasterProductCategories { get; set; }
        public virtual ICollection<AccessoryOrderDetail> AccessoryOrderDetails { get; set; }
        public virtual ICollection<AccessoryStock> AccessoryStocks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
