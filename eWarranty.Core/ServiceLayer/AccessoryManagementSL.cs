using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWarranty.Core.DataServices;
using eWarranty.Core.Hepler;
using eWarranty.Core.Models;
using eWarranty.Core.RequestModels;
using eWarranty.Core.ResponseModels;

namespace eWarranty.Core.ServiceLayer
{
    public class AccessoryManagementSL
    {
        public async Task<List<AccessoryResponse>> SearchAvailableAccessories(int CountryId, int ServiceCenterId, string SearchKey)
        {
            return await WebServiceUtils<List<AccessoryResponse>>.GetData(string.Format(ServiceEndPoints.SearchAvailableAccessories, CountryId, ServiceCenterId, SearchKey));
        }
      
        public async Task<List<ShoppingCartResponse>> GetShoppingCartItemsByPersonId(long pid)
        {
            return await WebServiceUtils<List<ShoppingCartResponse>>.GetData(ServiceEndPoints.GetShoppingCartItemsByPersonId + pid);
        }
        public async Task<List<AccessoryResponse>> GetAvailableAccessories(int CountryID)
        {
            return await WebServiceUtils<List<AccessoryResponse>>.GetData(string.Format(ServiceEndPoints.GetAvailableAccessories, CountryID));
        }
        public async Task<AccessoryResponse> GetAccessoryById(long id)
        {
            return await WebServiceUtils<AccessoryResponse>.GetData(ServiceEndPoints.GetAccessoryById + id);
        }
        public async Task<ReceiveContext<int>> AddToShoppingCart(ShoppingCartRequest shoppingCartRequest)
        {
            return await WebServiceUtils<ReceiveContext<int>>.PostData(ServiceEndPoints.AddToShoppingCart , shoppingCartRequest);
        }
        public async Task<APIResponse> UpdateShoppingCart(ShoppingCartUpdateRequest shoppingCartRequest)
        {
            return await WebServiceUtils<APIResponse>.PutData(string.Format(ServiceEndPoints.UpdateShoppingCart, shoppingCartRequest.ShoppingCartItemId), shoppingCartRequest);
        }

        public async Task<APIResponse> PostOrder(OrderRequest  orderRequest)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.PostOrder, orderRequest);
        }
        public async Task<List<OrderResponse>> GetOrdersByPersonId(long id)
        {
            return await WebServiceUtils<List<OrderResponse>>.GetData(ServiceEndPoints.GetOrdersByPersonId + id);
        }

        public async Task<List<OrderListResponse>> GetOrderListByPersonId(long id)
        {
            return await WebServiceUtils<List<OrderListResponse>>.GetData(string.Format(ServiceEndPoints.GetOrderListByPersonId, id));
        }

        public async Task<List<OrderResponse>> GetOrdersByOrderId(long OrderId,long PersonId)
        {
            return await WebServiceUtils<List<OrderResponse>>.GetData(string.Format(ServiceEndPoints.GetOrdersByOrderId, OrderId, PersonId));
        }

        public async Task<OrderResponse> GetOrdersByOrderIdPersonId(long OrderId, long PersonId)
        {
            return await WebServiceUtils<OrderResponse>.GetData(string.Format(ServiceEndPoints.GetOrdersByOrderIdPersonId, OrderId, PersonId));
        }

        public async Task<OrderResponse> GetOrder(long id)
        {
            return await WebServiceUtils<OrderResponse>.GetData(ServiceEndPoints.GetOrder + id);
        }
        public async Task<APIResponse> ReturnOrderRequest(OrderReturnRequest orderRequest)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.ReturnOrderRequest, orderRequest);
        }

        public async Task<APIResponse> FullReturnOrder(FullOrderReturnRequest fullOrderReturns)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.FullReturnOrder, fullOrderReturns);
        }

        public async Task<List<OrderDetailResponse>> GetAccessoryOrderByServiceCenterAndStatus(long ServiceCenterId, long DashboardStatus = 1)
        {
            return await WebServiceUtils<List<OrderDetailResponse>>.GetData(string.Format(ServiceEndPoints.GetAccessoryOrderByServiceCenterAndStatus, ServiceCenterId, DashboardStatus));
        }

        public async Task<APIResponse> AcceptOrder(AssignDeliveryRequest assignDeliveryRequest)
        {
            return await WebServiceUtils<APIResponse>.PostData(ServiceEndPoints.AcceptOrder, assignDeliveryRequest);
        }

        public async Task<APIResponse> RejectOrder(int OrderId)
        {
            return await WebServiceUtils<APIResponse>.PutData(ServiceEndPoints.RejectOrder + OrderId, null);
        }
    }
}
