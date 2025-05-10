using System;
using System.Collections.Generic;
using System.Linq;
using eWarranty.Core.Common;
using eWarranty.Core.Enums;
using eWarranty.Core.Hepler;
using Newtonsoft.Json;

namespace eWarranty.Core.ResponseModels
{
    public partial class OrderResponse
    {
        public long OrderId { get; set; }
        public long CustomerPersonId { get; set; }
        public int PaymentModeId { get; set; }
        public int DeliveryAddressId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public int? PromoCodeId { get; set; }
        public string OrderNo { get; set; }
        public decimal SubTotalAmount { get; set; }
        public decimal ShippingFeeAmount { get; set; }
        public string CurrencyCode { get; set; }

        public int Rotation { get; set; }

        public virtual PersonsVMResponse CustomerPerson { get; set; }
        public virtual AddressResponse DeliveryAddress { get; set; }
        public virtual PaymentModeResponse PaymentMode { get; set; }
        public virtual PromoCodeResponse PromoCode { get; set; }
        public virtual ICollection<AccessoryOrderDetailResponse> AccessoryOrderDetails { get; set; }
        public virtual ICollection<OrderDetailResponse> OrderDetails { get; set; }
        public virtual ICollection<OrderTrackingResponse> OrderTrackings { get; set; }
        public virtual ICollection<ReturnOrderRequestResponse> ReturnOrderRequests { get; set; }
    }

    public partial class PaymentModeResponse
    {
        public int PaymentModeId { get; set; }
        public string PaymentMode1 { get; set; }
    }

    public partial class AccessoryOrderDetailResponse
    {

        public long AccessoryOrderDetailId { get; set; }
        public long AccessoryMasterId { get; set; }
        public string SerialNumber { get; set; }
        public decimal Price { get; set; }
        public long? OrderId { get; set; }
        public long? OrderDetailId { get; set; }
        public int? DeliveredPersonId { get; set; }
        public string DeliveredPersonName { get; set; }
        public DateTime? DeliveredOn { get; set; }
        public DateTime? ReturnedOn { get; set; }
        public int AccessoryInStock { get; set; }

        public string DeliveryAddressFull { get; set; }
        public AddressResponse DeliveryAddress { get; set; }

        public OrderDetailResponse OrderDetail { get; set; }

        public bool IsReturnOrderVisible
        {
            get
            {
                DateTime FutureDate = (DateTime)DeliveredOn;
                FutureDate = FutureDate.AddDays(7);

                if (DateTime.Now >= FutureDate)
                    return false;
                else
                    return  true;
            }
        }

        public string AccessoryImageUrl
        {
            get
            {
                if (OrderDetail.AccessoryFiles != null && OrderDetail.AccessoryFiles.Count > 0)
                    return ServiceEndPoints.ServerImageUri + OrderDetail.AccessoryFiles.FirstOrDefault().Path;
                else
                    return "defaultprod.png";
            }
        }
    }

    public partial class OrderDetailResponse
    {
        public long OrderDetailId { get; set; }
        public long OrderId { get; set; }
        public long AccessoryMasterId { get; set; }
        public string AccessoryName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public string OrderDetailNo { get; set; }
        public decimal SubTotalAmount { get; set; }
        public int? OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ServiceCenterId { get; set; }
        public virtual ICollection<AccessoryFileResponse> AccessoryFiles { get; set; }
        public bool IsReturnOrderVisible { get; set; }        
        public DateTime? DeliveredOn { get; set; }
        public string CustomerName { get; set; }

        [JsonIgnore]
        public string CurrencyCode { get; set; }

        public ICollection<OrderTrackingResponse> OrderTrackings { get; set; }

        public ServiceCenterResponse ServiceCenterResponse { get; set; }

        public string OrderStatus
        {
            get
            {
                if (OrderStatusId != 0)
                {
                    if (OrderStatusId == (int)OrderStatusEnum.New)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "الجديد";
                        else
                            return "New";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.Processing)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "معالجة";
                        else
                            return "Processing";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.Shipped)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "شحنها";
                        else
                            return "Shipped";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.Delivered)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "تم التوصيل";
                        else
                            return "Delivered";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.Cancelled)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "ألغيت";
                        else
                            return "Cancelled";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.ReturnRequested)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "طلب الإرجاع";
                        else
                            return "Return Requested";
                    }
                    else
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "عاد";
                        else
                            return "Returned";
                    }
                }
                else
                    return "-";

                return "-";
            }
        }


        public string ProdcuImageUrl
        {
            get
            {
                if (AccessoryFiles != null && AccessoryFiles.Count > 0)
                    return ServiceEndPoints.ServerImageUri + AccessoryFiles.FirstOrDefault().Path;
                else
                    return "defaultprod.png";
            }
        }
    }

    public partial class OrderTrackingResponse
    {
        public int OrderTrackingId { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatusName { get; set; }
        public DateTime UpdatedDate { get; set; }
        public long OrderId { get; set; }

        public string OrderStatus
        {
            get
            {
                if (OrderStatusId != 0)
                {
                    if (OrderStatusId == (int)OrderStatusEnum.New)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "الجديد";
                        else
                            return "New";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.Processing)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "معالجة";
                        else
                            return "Processing";
                    }
                    else if(OrderStatusId == (int)OrderStatusEnum.Shipped)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "شحنها";
                        else
                            return "Shipped";
                    }
                    else if(OrderStatusId == (int)OrderStatusEnum.Delivered)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "تم التوصيل";
                        else
                            return "Delivered";
                    }
                    else if(OrderStatusId == (int)OrderStatusEnum.Cancelled)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "ألغيت";
                        else
                            return "Cancelled";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.ReturnRequested)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "طلب ارجاع";
                        else
                            return "Return Requested";
                    }
                    else if (OrderStatusId == (int)OrderStatusEnum.Returned)
                    {
                        if (CommonFunctions.LongCode == "ur")
                            return "عاد";
                        else
                            return "Returned";
                    }
                }
                else
                    return "-";

              return "-";
            }
        }
    }

    public partial class ReturnOrderRequestResponse
    {
        public long ReturnOrderRequestId { get; set; }
        public DateTime RequestedDate { get; set; }
        public long OrderDetailId { get; set; }
        public string Reason { get; set; }
        public int? Quantity { get; set; }
        public long? ClosedByPersonId { get; set; }
        public DateTime? ClosedDate { get; set; }
        public int? StatusId { get; set; }
        public string SupervisorComments { get; set; }
    }

}
