using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.Hepler;

namespace eWarranty.Core.ResponseModels
{
    public partial class AccessoryResponse
    {
        public long AccessoryMasterId { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int ServiceCenterId { get; set; }
        public string ServiceCenterName { get; set; }
        public decimal? DeliveryCost { get; set; }
        public string DeliveryDays { get; set; }
        public string Specification { get; set; }
        public bool? IsActive { get; set; }
        public string Number { get; set; }
        public virtual ICollection<PaymentModeResponse> AccessoryPaymentModes { get; set; }
        public virtual ICollection<AccessoryFileResponse> AccessoryFiles { get; set; }
        public bool IsVisible { get; set; }
        public long ShoppingCartItemId { get; set; }
        public int CartCount { get; set; }
        public string CurrencyCode { get; set; }
        //public string DeliveryDays
        //{
        //    get
        //    {
        //        if (DeliveryDays != null || DeliveryDays != string.Empty)
        //            return DeliveryDays;
        //        else
        //           return "0 Days";
        //    }
        //}

        public decimal ProdcuPrice
        {
            get
            {
                return Math.Round(Price, 2);
            }
        }
        public string StockStatus
        {
            get
            {
                return (Quantity > 0 ? "Available" : "Not Available");
            }
        }
        public string ProdcuImageUrl
        {
            get
            {
               if(AccessoryFiles != null && AccessoryFiles.Count>0)
                     return ServiceEndPoints.ServerImageUri + AccessoryFiles.FirstOrDefault().Path;
               else
                    return "defaultprod.png";
            }
        }
       
    }

    public partial class AccessoryStockResponse
    {
        public long AccessoryStockId { get; set; }
        public int StockFlow { get; set; }
        public int Quantity { get; set; }
        public DateTime StockDate { get; set; }
        public long AccessoryMasterId { get; set; }
    }

    public partial class AccessoryFileResponse
    {
        public long AccessoryFileInfoId { get; set; }
        public long AccessoryMasterId { get; set; }
        public int FileInfoId { get; set; }
        public string FileName { get; set; }
        public int? FileTypeId { get; set; }
        public string MimeType { get; set; }
        public string Path { get; set; }
    }
}
