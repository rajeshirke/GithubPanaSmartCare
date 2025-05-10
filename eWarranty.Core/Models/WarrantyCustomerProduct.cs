using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class WarrantyCustomerProduct
    {
        public WarrantyCustomerProduct()
        {
            ProductModels = new HashSet<ProductModel>();
        }

        public int WarrantyCustomerProductId { get; set; }
        public int? ProductClassificationId { get; set; }
        public long ProductModelId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsWarrantyActive { get; set; }
        public int? WarrantyMasterId { get; set; }
        public int WarrantyTypeId { get; set; }
        public int? ServiceCenterId { get; set; }
        public int? CountryId { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual WarrantyMaster WarrantyMaster { get; set; }
        public virtual ICollection<ProductModel> ProductModels { get; set; }
    }
}
