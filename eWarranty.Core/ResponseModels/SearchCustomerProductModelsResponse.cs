using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eWarranty.Core.ResponseModels
{ 
    public class SearchCustomerProductModelsResponse
    {
        public long ProductModelID { get; set; }
        public int CustomerID { get; set; }
        public bool? IsProductExistInPRISM { get; set; }
        public int? ProductCategoryID { get; set; }
        public int PurchaseCountryId { get; set; }
        public string ModelNumber { get; set; }
        public string SerialNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string RegistrationNumber { get; set; }
        public string ReferenceNo { get; set; }
        public bool? IsAmcRequested { get; set; }
        public string PurchaseInvoiceNumber { get; set; }
        public DateTime? PurchaseInvoiceDate { get; set; }
        public int? ProductClassificationID { get; set; }
        public string ProductClassification { get; set; }
        public string PurchaseCountryName { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? ActiveWarrantyCustomerProductID { get; set; }  

    }




}
