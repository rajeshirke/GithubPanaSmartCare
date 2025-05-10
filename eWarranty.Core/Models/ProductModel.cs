using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace eWarranty.Core.Models
{
    public partial class ProductModel
    {
        public ProductModel()
        {
            Accessories = new HashSet<Accessory>();
            AmcRequestCustomers = new HashSet<AmcRequestCustomer>();
            ProductApprovalRequests = new HashSet<ProductApprovalRequest>();
            ProductFiles = new HashSet<ProductFile>();
            ServiceRequests = new HashSet<ServiceRequest>();
            WarrantyCustomerProducts = new HashSet<WarrantyCustomerProduct>();
        }

        public long ProductModelId { get; set; }
        public long CustomerId { get; set; }
        public bool? IsProductExistInPrism { get; set; }
        public int? ProductCategoryId { get; set; }
        public string ProductClassificationName { get; set; }
        public int PurchaseCountryId { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string ReferenceNo { get; set; }
        public bool? IsAmcRequested { get; set; }
        public string DealerName { get; set; }
        public string DealerAddress { get; set; }
        public string PurchaseInvoiceNumber { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public string CustomerRemark { get; set; }
        public bool? IsProductModelInWarranty { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? ActiveWarrantyCustomerProductId { get; set; }

        public virtual WarrantyCustomerProduct ActiveWarrantyCustomerProduct { get; set; }
        public virtual Country PurchaseCountry { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<AmcRequestCustomer> AmcRequestCustomers { get; set; }
        public virtual ICollection<ProductApprovalRequest> ProductApprovalRequests { get; set; }
        public virtual ICollection<ProductFile> ProductFiles { get; set; }
        public virtual ICollection<ServiceRequest> ServiceRequests { get; set; }
        public virtual ICollection<WarrantyCustomerProduct> WarrantyCustomerProducts { get; set; }
    }
}
